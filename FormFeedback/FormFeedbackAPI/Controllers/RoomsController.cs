using FormFeedbackAPI.Bases;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace FormFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : BasesController<Room, RoomRepository>
    {
        private readonly RoomRepository _repository;

        public RoomsController(RoomRepository roomRepository) : base(roomRepository)
        {
            _repository = roomRepository;
        }

        [HttpGet]
        [Route("GetCount/")]
        public IActionResult Get()
        {
            var getall = _repository.Count();
            return Ok(getall);
        }

        [HttpGet("{mth}/{yrs}")]
        [Route("GetCountEvent/{mth}/{yrs}")]
        public IActionResult GetEvent(int mth, int yrs)
        {
            var getall = _repository.CountEvent(mth, yrs);
            return Ok(getall);
        }
    }
}