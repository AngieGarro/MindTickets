using Core;
using Core.Managers;
using Core.RESTManagers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class SUNPEController : ControllerBase
	{
		[HttpPost]
		[Route("SendTEF")]
		public async Task<IActionResult> SendTEF(TEF sunpe)
		{
			try
			{
				var sm = new SUNPEManager();
				sm.PostToApi(sunpe);
				return Ok(sunpe);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("RetrieveAll")]
		public async Task<IActionResult> RetrieveAll()
		{
			try
			{
				var sm = new SUNPEManager();
				var results = sm.GetToApi;
				return Ok(results);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
