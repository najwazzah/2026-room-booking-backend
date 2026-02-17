using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RoomBookingBackend.Data;
using RoomBookingBackend.Models;
using RoomBookingBackend.DTOs;

namespace RoomBookingBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomBookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoomBookingController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //// <summary>
        /// Ambil semua booking ruangan.
        /// </summary>
        /// <returns>List RoomBookingReadDto</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RoomBookingReadDto>>> GetBookings()
        {
            var bookings = await _context.RoomBookings.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<RoomBookingReadDto>>(bookings));
        }

        /// <summary>
        /// Ambil booking berdasarkan ID.
        /// </summary>
        /// <param name="id">ID booking</param>
        /// <returns>RoomBookingReadDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoomBookingReadDto>> GetBooking(int id)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null) return NotFound();
            return Ok(_mapper.Map<RoomBookingReadDto>(booking));
        }

        // POST: api/RoomBooking
        [HttpPost]
        public async Task<ActionResult<RoomBookingReadDto>> CreateBooking(RoomBookingCreateDto dto)
        {
            var booking = _mapper.Map<RoomBooking>(dto);
            booking.CreatedAt = DateTime.Now;

            _context.RoomBookings.Add(booking);
            await _context.SaveChangesAsync();

            var readDto = _mapper.Map<RoomBookingReadDto>(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, readDto);
        }

        // PUT: api/RoomBooking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, RoomBookingCreateDto dto)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null) return NotFound();

            _mapper.Map(dto, booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/RoomBooking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null) return NotFound();

            _context.RoomBookings.Remove(booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}