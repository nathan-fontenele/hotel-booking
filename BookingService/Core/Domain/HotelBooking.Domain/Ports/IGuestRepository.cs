using System.Threading.Tasks;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Ports;

public interface IGuestRepository
{
    Task<Guest> Get(int id);
    Task<string> Create(Guest guest);
}