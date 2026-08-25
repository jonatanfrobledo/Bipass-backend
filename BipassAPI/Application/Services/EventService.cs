using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<List<EventDto>> GetEventsAsync()
        {
            var events = await _eventRepository.GetEvents();
            return events.Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Date = e.Date,
                VenueName = e.Venue.Name,
                IsStreaming = e.IsStreaming,
                TicketTypes = e.TicketTypes.Select(tt => new TicketTypeDto
                {
                    Id = tt.Id,
                    Name = tt.Name,
                    Price = tt.Price,
                    QuantityAvailable = tt.QuantityAvailable
                }).ToList()
            }).ToList();
        }
        public async Task<EventDto?> GetEventByIdAsync(int id)
        {
            var eventItem = await _eventRepository.GetEventById(id);
            if (eventItem == null)
            {
                return null;
            }
            return new EventDto
            {
                Id = eventItem.Id,
                Name = eventItem.Name,
                Description = eventItem.Description,
                Date = eventItem.Date,
                VenueName = eventItem.Venue.Name,
                IsStreaming = eventItem.IsStreaming,
                TicketTypes = eventItem.TicketTypes.Select(tt => new TicketTypeDto
                {
                    Id = tt.Id,
                    Name = tt.Name,
                    Price = tt.Price,
                    QuantityAvailable = tt.QuantityAvailable
                }).ToList()
            };
        }
        public async Task<int> AddEventAsync(CreateEventDto dto)
        {
            var newEvent = new Event
            {
                Name = dto.Name,
                Description = dto.Description,
                Date = dto.Date,
                IsStreaming = dto.IsStreaming,
                StreamingUrl = dto.StreamingUrl,
                // ImageUrl = dto.ImageUrl,
                Venue = new Venue
                {
                    Name = dto.Venue.Name,
                    Address = dto.Venue.Address,
                    Capacity = dto.Venue.Capacity
                },
                TicketTypes = dto.TicketTypes.Select(t => new TicketType
                {
                    Name = t.Name,
                    Price = t.Price,
                    QuantityAvailable = t.QuantityAvailable
                }).ToList()
            };

            // Agregar a la DB y guardar cambios
            
            await _eventRepository.AddEvent(newEvent);

            return newEvent.Id;
        }
        public async Task UpdateEventAsync(int id, UpdateEventDto dto)
        {
            // 1. Buscar la entidad existente en la base de datos a través del repositorio
            var existingEvent = await _eventRepository.GetEventById(id);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException($"No se encontró el evento con ID {id}.");
            }

            // 2. Actualizar las propiedades de la entidad existente con los datos del DTO
            existingEvent.Name = dto.Name;
            existingEvent.Description = dto.Description;
            existingEvent.Date = dto.Date;
            existingEvent.IsStreaming = dto.IsStreaming;
            existingEvent.StreamingUrl = dto.StreamingUrl;
            existingEvent.ImageUrl = dto.ImageUrl;

            if (existingEvent.Venue != null && dto.Venue != null)
            {
                existingEvent.Venue.Name = dto.Venue.Name;
                existingEvent.Venue.Address = dto.Venue.Address;
                existingEvent.Venue.Capacity = dto.Venue.Capacity;
            }

            // 3. Persistir los cambios usando el repositorio
            await _eventRepository.UpdateEvent(existingEvent);
        }

        public async Task DeleteEventAsync(int id)
        {
            var existingEvent = await _eventRepository.GetEventById(id);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException($"No se encontró el evento con ID {id}.");
            }

            await _eventRepository.DeleteEvent(id);
        }
    }
}
