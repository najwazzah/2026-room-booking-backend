using AutoMapper;
using RoomBookingBackend.Models;
using RoomBookingBackend.DTOs;

namespace RoomBookingBackend.Profiles
{
    public class RoomBookingProfile : Profile
    {
        public RoomBookingProfile()
        {
            // Entity -> DTO (untuk response GET)
            CreateMap<RoomBooking, RoomBookingReadDto>();

            // DTO -> Entity (untuk request POST/PUT)
            CreateMap<RoomBookingCreateDto, RoomBooking>();
        }
    }
}