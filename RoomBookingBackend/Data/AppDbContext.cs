using Microsoft.EntityFrameworkCore;
using RoomBookingBackend.Models;

namespace RoomBookingBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RoomBooking> RoomBookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomBooking>().HasData(
                new RoomBooking
                {
                    Id = 100,
                    RoomName = "B201",
                    BookedBy = "Najwa",
                    Date = new DateTime(2026, 02, 14, 10, 00, 00),
                    Status = "Confirmed",
                    CreatedAt = new DateTime(2026, 02, 14, 09, 00, 00)
                },
                new RoomBooking
                {
                    Id = 101,
                    RoomName = "B202",
                    BookedBy = "Nando",
                    Date = new DateTime(2026, 02, 15, 14, 00, 00),
                    Status = "Pending",
                    CreatedAt = new DateTime(2026, 02, 14, 09, 30, 00)
                },
                new RoomBooking
                {
                    Id = 102,
                    RoomName = "B203",
                    BookedBy = "Andi",
                    Date = new DateTime(2026, 02, 16, 09, 00, 00),
                    Status = "Cancelled",
                    CreatedAt = new DateTime(2026, 02, 14, 10, 00, 00)
                }
            );
        }
    }
}