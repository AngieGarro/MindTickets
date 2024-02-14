using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxClientController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Tax tax)
        {
            try
            {
                var tm = new TaxManager();
                tm.Create(tax);
                return Ok(tax);
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
                var tm = new TaxManager();
                var results = tm.RetrieveAll();
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
                var tax = new Tax();
                var tm = new TaxManager();
                tax = tm.RetrieveById(id);
                return Ok(tax);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Tax tax)
        {
            try
            {
                var tm = new TaxManager();
                tm.Delete(tax);
                return Ok(tax);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Tax tax)
        {
            try
            {
                var tm = new TaxManager();
                tm.Update(tax);
                return Ok(tax);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}
