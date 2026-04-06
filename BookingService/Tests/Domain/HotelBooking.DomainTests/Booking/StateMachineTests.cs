using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using Action = HotelBooking.Domain.Enums.Action;

namespace HotelBooking.DomainTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ShouldAlwaysStartWithCreatedStatus()
    {
        var booking = new Booking();
        Assert.That(Status.Created, 
            Is.EqualTo(booking.CurrentStatus));
    }

    [Test]
    public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus()
    {
        var booking = new Booking();
        
        booking.ChangeState(Action.Pay);
        
        Assert.That(Status.Paid,
            Is.EqualTo(booking.CurrentStatus));
    }
    
    [Test]
    public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
    {
        var booking = new Booking();
        
        booking.ChangeState(Action.Cancel);
        
        Assert.That(Status.Canceled,
            Is.EqualTo(booking.CurrentStatus));
    }
    
    [Test]
    public void ShouldSetStatusToFinishedWhenFinishingAPaidBooking()
    {
        var booking = new Booking();
        
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Finish);
        
        Assert.That(Status.Finished,
            Is.EqualTo(booking.CurrentStatus));
    }
    
    [Test]
    public void ShouldSetStatusToRefoundedWhenFinishingAPaidBooking()
    {
        var booking = new Booking();
        
        booking.ChangeState(Action.Pay);
        booking.ChangeState(Action.Refound);
        
        Assert.That(Status.Refounded,
            Is.EqualTo(booking.CurrentStatus));
    }
    
    [Test]
    public void ShouldSetStatusToCreatedWhenReopenedACanceledBooking()
    {
        var booking = new Booking();
        
        booking.ChangeState(Action.Cancel);
        booking.ChangeState(Action.Reopened);
        
        Assert.That(Status.Created,
            Is.EqualTo(booking.CurrentStatus));
    }
    
    [Test]
    public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus()
    {
        var booking = new Booking();
        
        booking.ChangeState(Action.Refound);
        
        Assert.That(Status.Created,
            Is.EqualTo(booking.CurrentStatus));
    }
}