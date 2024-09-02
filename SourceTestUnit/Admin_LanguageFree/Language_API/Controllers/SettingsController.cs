using BusinessObject.DTO;
using BusinessObject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reponsitory;
using Reponsitory.Service;
using System;
using System.Threading.Tasks;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly SettingsIRepository _settingsrepository;

        public SettingsController(SettingsIRepository settingsIRepository)
        {
            _settingsrepository = settingsIRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSetting([FromBody] SettingsDTO settings)
        {
            try
            {
                await _settingsrepository.NewSettings(settings);
                return Ok("Setting created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetSettings(int userId)
        {
            try
            {
                var settings = await _settingsrepository.GetSettings(userId);
                if (settings == null)
                {
                    return BadRequest("Settings Not Found");
                }
                return Ok(settings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

       
    }
}
