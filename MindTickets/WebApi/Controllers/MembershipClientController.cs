
using Core;
using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class MembershipClientController : ControllerBase
	{
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(Membership membership)
		{
			try
			{
				var mm = new MembershipManager();
				mm.Create(membership);
				return Ok(membership);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		
		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> Delete(Membership membership)
		{
			try
			{
				var mm = new MembershipManager();
				mm.Delete(membership);
				return Ok(membership);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		

        [HttpDelete]
        [Route("DeleteID")]
        public async Task<IActionResult> DeleteID(int Id)
        {
            try
            {
                var mm = new MembershipManager();
                mm.DeleteID(Id);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
		[Route("Update")]
		public async Task<IActionResult> Update(Membership membership)
		{
			try
			{
				var mm = new MembershipManager();
				mm.Update(membership);
				return Ok(membership);
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
				var mm = new MembershipManager();
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
		public async Task<IActionResult> RetrieveById(int id)
		{
			try
			{
				var membership = new Membership() { Id = id };
				var mm = new MembershipManager();
				membership = mm.RetrieveById(membership);
				return Ok(membership);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
        

    }
}
