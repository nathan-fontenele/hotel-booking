using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.ValueObjects;

public class PersonId
{
    public string IdNumber { get; set; }
    public DocumentType  DocumentType { get; set; }
    
}