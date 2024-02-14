using Core.Managers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DetailsEventsController : Controller
	{
		[HttpGet]
		[Route("RetrieveAllDetailsEvents")]
		public async Task<IActionResult> RetrieveAllDetailsEvents()
		{
			try
			{
				var dm = new DetailsEventManager();
				var results = dm.RetrieveAll();
				return Ok(results);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpGet]
		[Route("RetrieveByIdDetailsEvents")]
		public async Task<IActionResult> RetrieveByIdDetailsEvents(int Id)
		{
			try
			{
				var dm = new DetailsEventManager();
				var results = dm.RetrieveById(Id);
				return Ok(results);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}
	}
}
