using System;

namespace RoomBookingBackend.DTOs
{
    public class RoomBookingReadDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string BookedBy { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
    }
}