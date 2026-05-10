using HotelBooking.Application;
using HotelBooking.Application.Guest.DTOs;
using HotelBooking.Application.Guest.Requests;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Ports;
using Moq;

namespace HotelBooking.ApplicationTests;

public class Tests
{
    private GuestManager _guestManager;
    [SetUp]
    public void Setup()
    {
       
    }

    [Test]
    public async Task CreateGuest_WithValidData_ReturnsSuccessResponse()
    {
        var guestDto = new GuestDto
        {
            Name = "Surname",
            Surname = "Smith",
            Email = "teste@teste.com",
            DocumentId = "abcd",
            IdTypeCode = 1
        };

        var request = new CreateGuestRequest()
        {
            Data = guestDto,
        };
        
        var moqRepo = new Mock<IGuestRepository>();
        moqRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult("222"));
        _guestManager = new GuestManager(moqRepo.Object);
        
        var response = await _guestManager.CreateGuest(request);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Success, Is.True);
    }

    [Test]
    public async Task CreateGuest_WithValidData_DataInResponseMatchesRequest()
    {
        var guestDto = new GuestDto
        {
            Name = "Surname",
            Surname = "Smith",
            Email = "teste@teste.com",
            DocumentId = "abcd",
            IdTypeCode = 1
        };

        var request = new CreateGuestRequest()
        {
            Data = guestDto,
        };
        
        var moqRepo = new Mock<IGuestRepository>();
        moqRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult("222"));
        _guestManager = new GuestManager(moqRepo.Object);
        
        var response = await _guestManager.CreateGuest(request);
        
        Assert.That(response.Data, Is.EqualTo(request.Data));
        Assert.That(response.Success, Is.True);
    }

    [Test]
    public async Task CreateGuest_WithNullDocument_ReturnsInvalidPersonIdErro()
    {
        var guestDto = new GuestDto
        {
            Name = "Surname",
            Surname = "Smith",
            Email = "teste@teste.com",
            DocumentId = null,
            IdTypeCode = 1
        };

        var request = new CreateGuestRequest();
        request.Data = guestDto;
        
        var moqRepo = new Mock<IGuestRepository>();
        moqRepo.Setup(x => x.Create(It.IsAny<Guest>())).Returns(Task.FromResult("222"));
        _guestManager = new GuestManager(moqRepo.Object);
        
        var response = await _guestManager.CreateGuest(request);
        
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Success, Is.False);
        Assert.That(response.ErrorCode, Is.EqualTo(ErrorCodes.INVALID_PERSON_ID));
    }
}