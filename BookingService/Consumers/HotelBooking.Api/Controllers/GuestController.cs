using HotelBooking.Application;
using HotelBooking.Application.Guest.DTOs;
using HotelBooking.Application.Guest.Requests;
using HotelBooking.Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GuestController : ControllerBase
{
    private readonly ILogger<GuestController> _logger;
    private readonly IGuestManager _ports;

    public GuestController(ILogger<GuestController> logger, IGuestManager ports)
    {
        _logger = logger;
        _ports = ports;
    }

    [HttpPost]
    public async Task<ActionResult<GuestDto>> Post(GuestDto guestDto)
    {
        var request = new CreateGuestRequest
        {
            Data = guestDto
        };
        
        var res = await _ports.CreateGuest(request);

        if (res.Success) return Created("", res.Data);

        if (res.ErrorCode == ErrorCodes.NOT_FOUND)
        {
            return BadRequest(res);
        }
        else if (res.ErrorCode == ErrorCodes.INVALID_PERSON_ID)
        {
            return BadRequest(res);
        }
        else if (res.ErrorCode == ErrorCodes.MISSING_INFORMATION)
        {
            return BadRequest(res);
        }
        else if (res.ErrorCode == ErrorCodes.COULD_NOT_STORE_DATA)
        {
            return  BadRequest(res);
        }
        
        _logger.LogError("Response with unknown ErrorCode returned", res);
        return BadRequest(res);
    }
}