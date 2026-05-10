using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Ports;

namespace HotelBooking.Data;

public class GuestRepository : IGuestRepository
{
    private readonly AppDbContext _context;
    public GuestRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Task<Guest> Get(int id)
    {
        var guest = _context.Guests.Where(g => g.Id == id);
        return Task.FromResult(guest.FirstOrDefault());
    }

    public async Task<string> Create(Guest guest)
    {
        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();
        return await Task.FromResult(guest.Document.IdNumber);
    }
}