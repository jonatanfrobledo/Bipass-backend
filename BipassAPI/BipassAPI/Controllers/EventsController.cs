using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // Descomentar el Authorize cuando tengas configurado el rol de admin
        // [Authorize(Roles = "admin,super-admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEventDto createEventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEventId = await _eventService.AddEventAsync(createEventDto);

            // Retorna un 201 Created con el ID del nuevo evento generado
            return CreatedAtAction(nameof(GetById), new { id = newEventId }, new { id = newEventId });
        }

        [Authorize(Roles = "admin,super-admin")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEventDto updateEventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _eventService.UpdateEventAsync(id, updateEventDto);
                return NoContent(); // 204 No Content para actualizaciones exitosas
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "admin,super-admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _eventService.DeleteEventAsync(id);
                return NoContent(); // 204 No Content para eliminaciones exitosas
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}