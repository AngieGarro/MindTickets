using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : Controller
    {
        //[HttpPost]
        //[Route("CreateEvent")]
        ////Funcion para reservar el asieto
        //public async Task<IActionResult> CreateStage(Seat seat)
        //{
        //    try
        //    {
        //        var mm = new StageManager();
        //        mm.CreateEvent(events);
        //        return Ok(events);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete]
        //[Route("Delete")]
        //public async Task<IActionResult> Delete(User user)
        //{
        //    try
        //    {
        //        var mm = new UserManager();
        //        mm.Delete(user);
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut]
        //[Route("Update")]
        //public async Task<IActionResult> Update(User user)
        //{
        //    try
        //    {
        //        var mm = new UserManager();
        //        mm.Delete(user);
        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        [HttpGet]
            [Route("RetrieveAll")]
            public async Task<IActionResult> RetrieveAll()
            {
                try
                {

                    var mm = new StageManager();
                    var results = mm.RetrieveAll();
                    return Ok(results);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet]
            [Route("RetrieveById")]
            //consulta los asientos por id de evento, id de escenario y sector
            public async Task<IActionResult> RetrieveById(int IdEvent, int IdStage, int SectorId)
            {
                try
                {
                    /*var seat = new Seat() {
                        IdEvent = IdEvent,
                        IdStage = IdStage,
                        sectorId = SectorId
                    };*/
                    var mm = new StageManager();
                    var seat = mm.RetrieveById(IdEvent, IdStage, SectorId);
                    return Ok(seat);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    }
}
