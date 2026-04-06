using HotelBooking.Domain.ValueObjects;

namespace HotelBooking.Domain.Entities;

public class Guest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public PersonId Document { get; set; }
}