using System;
using HotelBooking.Domain.Enums;
using Action = HotelBooking.Domain.Enums.Action;

namespace HotelBooking.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public DateTime PlacedAt { get; set; }
    public DateTime StartAt { get; set; }
    public Room Room { get; set; }
    public Guest Guest { get; set; }
    public DateTime EndAt { get; set; }
    private Status  Status { get; set; }
    
    public Status CurrentStatus { get { return Status; } }

    public Booking()
    {
        Status = Status.Created;
    }

    public void ChangeState(Action action)
    {
        Status = (Status, action) switch
        {
            (Status.Created, Action.Pay) => Status.Paid,
            (Status.Created, Action.Cancel) => Status.Canceled,
            (Status.Paid, Action.Finish) => Status.Finished,
            (Status.Paid, Action.Refound) => Status.Refounded,
            (Status.Canceled, Action.Reopened) => Status.Created,
            _ => Status
        };
    }
}