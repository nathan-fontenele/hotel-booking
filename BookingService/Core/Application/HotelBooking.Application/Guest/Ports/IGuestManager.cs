using HotelBooking.Application.Guest.DTOs;
using HotelBooking.Application.Guest.Requests;
using HotelBooking.Application.Guest.Responses;

namespace HotelBooking.Application.Ports;

public interface IGuestManager
{
    Task<GuestResponse> CreateGuest(CreateGuestRequest request);
}