using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public virtual DbSet<Guest> Guests { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new  GuestConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
    }
}