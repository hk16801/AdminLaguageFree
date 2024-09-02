using BusinessObject.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reponsitory;
using System;
using System.Threading.Tasks;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLogsController : ControllerBase
    {
        private readonly AccessLogsIRepository _accesslogsRepository;

        public AccessLogsController(AccessLogsIRepository accessLogsIRepository)
        {
            _accesslogsRepository = accessLogsIRepository;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewAccessLogs([FromBody] AccessLogsDTO accessLogs)
        {
            try
            {
                await _accesslogsRepository.NewAccessLogs(accessLogs);
                return Ok("AccessLog created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpGet]
        public async Task<IActionResult> GetAllAccessLogs()
        {
            try
            {
                var accessLogs = await _accesslogsRepository.GetAllAccessLogs();
                if (accessLogs == null)
                {
                    return BadRequest("AccessLog Not Found");
                }
                return Ok(accessLogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }


    }
}
