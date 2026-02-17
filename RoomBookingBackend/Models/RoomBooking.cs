using System;
using System.ComponentModel.DataAnnotations;

namespace RoomBookingBackend.Models
{
    public class RoomBooking
    {
        public int Id { get; set; }

        [Required]
        public string RoomName { get; set; } = string.Empty;

        [Required]
        public string BookedBy { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}