using BusinessObject.DTO;
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
    public class LanguageLogsController : ControllerBase
    {
        private readonly LanguageLogsIRepository _languagelogsRepository;

        public LanguageLogsController(LanguageLogsIRepository languageLogsIRepository)
        {
            _languagelogsRepository = languageLogsIRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewLanguageLogs([FromBody] LanguageLogsDTO language)
        {
            try
            {
                await _languagelogsRepository.NewLanguageLogs(language);
                return Ok("LanguageLog created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLanguageLogs()
        {
            try
            {
                var languageLogs = await _languagelogsRepository.GetAllLanguageLogs();
                if (languageLogs == null)
                {
                    return BadRequest("LanguageLog Not Found");
                }
                return Ok(languageLogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
