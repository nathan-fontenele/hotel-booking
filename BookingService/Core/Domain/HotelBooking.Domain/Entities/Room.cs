using HotelBooking.Domain.ValueObjects;

namespace HotelBooking.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public Price Price { get; set; }
    public bool InMaintenance { get; set; }

    public bool IsAvailable
    {
        get
        {
            if (!InMaintenance || HasGuest) return false;
            
            return true;
        }
    }
    
    public bool HasGuest
    {
        get { return true; }
    }
}