using Microsoft.EntityFrameworkCore;
using Presentation.Entities;

namespace Presentation.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<BookingOwnerEntity> BookingOwner { get; set; }
    public DbSet<BookingAddressEntity> BookingAddress { get; set; }
}
