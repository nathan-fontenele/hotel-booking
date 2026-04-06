using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.ValueObjects;

public class Price
{
    public decimal Value { get; set; }
    public AcceptedCurrencies Currency { get; set; }
}