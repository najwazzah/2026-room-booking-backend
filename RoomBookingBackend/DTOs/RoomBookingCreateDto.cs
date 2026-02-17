using System;
using System.ComponentModel.DataAnnotations;

namespace RoomBookingBackend.DTOs
{
    public class RoomBookingCreateDto
    {
        [Required(ErrorMessage = "RoomName wajib diisi")]
        [StringLength(100, ErrorMessage = "RoomName maksimal 100 karakter")]
        public string RoomName { get; set; } = string.Empty;

        [Required(ErrorMessage = "BookedBy wajib diisi")]
        [StringLength(50, ErrorMessage = "BookedBy maksimal 50 karakter")]
        public string BookedBy { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date wajib diisi")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Status wajib diisi")]
        [RegularExpression("^(Pending|Confirmed|Cancelled)$", ErrorMessage = "Status harus Pending, Confirmed, atau Cancelled")]
        public string Status { get; set; } = "Pending";
    }
}