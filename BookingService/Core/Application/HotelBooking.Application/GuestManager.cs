using HotelBooking.Application.Guest.DTOs;
using HotelBooking.Application.Guest.Requests;
using HotelBooking.Application.Guest.Responses;
using HotelBooking.Application.Ports;
using HotelBooking.Domain.Ports;
using HotelBooking.Domain.Exceptions;

namespace HotelBooking.Application;

public class GuestManager : IGuestManager
{
    private readonly IGuestRepository _guestRepository;
    public GuestManager(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }
    public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
    {
        try
        {
            var guest = GuestDto.MapToEntity(request.Data);
            await guest.Save(_guestRepository);
            return new GuestResponse
            {
                Data = request.Data,
                Success = true,
            };
        }
        catch (InvalidDocumentException e)
        {
            return new GuestResponse
            {
                Success = false,
                ErrorCode = ErrorCodes.INVALID_PERSON_ID,
                Message = "The ID is not valid"
            };
        }
        catch (MissingRequiredInformation e)
        {
            return new GuestResponse
            {
                Success = false,
                ErrorCode = ErrorCodes.MISSING_INFORMATION,
                Message = "Missing required information"
            };
        }
        catch (Exception e)
        {
            return new GuestResponse
            {
                Success =  false,
                ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                Message = "There was an error saving the data",
            };
        }
    }
}