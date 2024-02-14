using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        //PRINCIPAL EVENTS
        [HttpPost]
        [Route("CreateEvent")]
      
        public async Task<IActionResult> CreateEvent(Events events)
        {
            try
            {
                var mm = new EventsManager();
                mm.CreateEvents(events);
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllEvents")]
        public async Task<IActionResult> RetrieveAllEvents()
        {
            try
            {
                var mm = new EventsManager();
                var results = mm.RetrieveAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("RetrieveMyEvents")]
        public async Task<IActionResult> RetrieveMyEvents(int id)
        {
            try
            {
                var mm = new EventsManager();
                var results = mm.RetrieveMyEvents(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("RetrieveCountEvents")]
        public async Task<IActionResult> RetrieveCountEvents(int id)
        {
            try
            {
                var mm = new EventsManager();
                var results = mm.RetrieveCount(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
		[Route("UpdateEvent")]

		public async Task<IActionResult> UpdateEvent(Events events)
		{
			try
			{
				var mm = new EventsManager();
				mm.Update(events);
				return Ok(events);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
