using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BipassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await _eventService.GetEventsAsync();
            return Ok(events);
        }

        [Authorize(Roles = "SuperAdmin,Organizer")]
        [HttpGet("organizer/my-events")]
        public async Task<IActionResult> GetMyEvents()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int organizerId))
            {
                return Unauthorized(new { message = "Token inválido o ID de usuario no encontrado." });
            }

            var myEvents = await _eventService.GetEventsByOrganizerIdAsync(organizerId);
            return Ok(myEvents);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventItem = await _eventService.GetEventByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound(new { message = $"No se encontró el evento con ID {id}." });
            }
            return Ok(eventItem);
        }

        [HttpGet("{id:int}/tickets")]
        public async Task<IActionResult> GetTicketTypesByEvent(int id)
        {
            try
            {
                var tickets = await _eventService.GetTicketTypesByEventIdAsync(id);
                return Ok(tickets);
            }
            catch (Exception)
            {
                return Ok(new List<object>());
            }
        }

        [Authorize(Roles = "SuperAdmin,Organizer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEventDto createEventDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int organizerId = int.Parse(userIdClaim ?? "0");

            var newEventId = await _eventService.AddEventAsync(createEventDto, organizerId);
            return CreatedAtAction(nameof(GetById), new { id = newEventId }, new { id = newEventId });
        }

        [Authorize(Roles = "SuperAdmin,Organizer")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEventDto updateEventDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
                int currentUserId = int.Parse(userIdClaim ?? "0");

                await _eventService.UpdateEventAsync(id, updateEventDto, currentUserId, userRole);
                return NoContent();
            }
            catch (UnauthorizedAccessException) { return Forbid(); }
            catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        }

        [Authorize(Roles = "SuperAdmin,Organizer")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
                int currentUserId = int.Parse(userIdClaim ?? "0");

                await _eventService.DeleteEventAsync(id, currentUserId, userRole);
                return NoContent();
            }
            catch (UnauthorizedAccessException) { return Forbid(); }
            catch (KeyNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        }
    }
}