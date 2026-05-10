namespace HotelBooking.Application;

public enum ErrorCodes
{
    NOT_FOUND = 0,
    COULD_NOT_STORE_DATA = 1,
    INVALID_PERSON_ID = 2,
    MISSING_INFORMATION = 3
}
public abstract class Response
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ErrorCodes ErrorCode { get; set; }
}