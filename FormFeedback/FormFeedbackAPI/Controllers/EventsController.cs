using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormFeedbackAPI.Bases;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BasesController<Event, EventRepository>
    {
        private readonly EventRepository _repository;

        public EventsController(EventRepository eventRepository) : base(eventRepository)
        {
            _repository = eventRepository;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(Event events)
        {
            events.Date = Convert.ToDateTime(events.Date.ToString("MM/dd/yyyy"));
            events.StartTime = Convert.ToDateTime(events.StartTime.ToString("HH:mm"));
            events.EndTime = Convert.ToDateTime(events.EndTime.ToString("HH:mm"));
            events.Create();
            var create = await _repository.Post(events);
            if (create > 0)
            {
                return Ok(events);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("Get/")]
        public IActionResult Get()
        {
            var getall = _repository.Get();
            return Ok(getall);
        }

        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var getall = _repository.Get(id);
            return Ok(getall);
        }
    }
}