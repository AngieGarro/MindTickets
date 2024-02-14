using Core.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase 
    {

        [HttpGet]
        [Route("RetrieveMyFutureEvents")]
        public async Task<IActionResult> RetrieveMyFutureEvents(int id)
        {
            try
            {
                var tm = new TicketManager();
                var results = tm.RetrieveMyFutureEvents(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("RetrieveMyPastEvents")]
        public async Task<IActionResult> RetrieveMyPastEvents(int id)
        {
            try
            {
                var tm = new TicketManager();
                var results = tm.RetrieveMyPastEvents(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
