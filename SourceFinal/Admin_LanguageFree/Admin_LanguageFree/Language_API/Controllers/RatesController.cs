using BusinessObject.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reponsitory;
using Reponsitory.IService;
using System;
using System.Threading.Tasks;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly RatesIRepository _ratesrepository;
        public CheckRate check = new CheckRate();
        public RatesController(RatesIRepository ratesRepository)
        {
            _ratesrepository = ratesRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRate([FromBody] RatesDTO rates)
        {
            try
            {
                await _ratesrepository.NewRates(rates);
                return Ok("Rate created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpGet]
        public async Task<IActionResult> GetAllRates()
        {
            try
            {
                var rates = await _ratesrepository.GetAllRates();
                if (rates == null)
                {
                    return BadRequest("Rate Not Found");
                }
                return Ok(rates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("canRate/{userId}")]
        public async Task<IActionResult> CanUserRate(int userId)
        {
            try
            {
                bool canRate = await _ratesrepository.CanRate(userId);
                check.IsChecked = canRate;
                return Ok(check);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
