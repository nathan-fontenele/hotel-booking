using HotelBooking.Application.Guest.DTOs;

namespace HotelBooking.Application.Guest.Requests;

public class CreateGuestRequest
{
    public GuestDto Data { get; set; }
}