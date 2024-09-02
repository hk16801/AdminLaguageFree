using BusinessObject.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reponsitory;
using Reponsitory.Service;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationHistorysController : ControllerBase
    {
        private readonly TranslationHistorysIRepository _repository;

        public TranslationHistorysController(TranslationHistorysIRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewTranslationHistory([FromBody] TranslationHistorysDTO translation)
        {
            try
            {

                await _repository.NewTranslationHistorys(translation);
                return Ok("Translation history created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllTranslationHistorys(int userId)
        {
            try
            {
                var translationHistorys = await _repository.GetAllTranslationHistorys(userId);
                if (translationHistorys == null)
                {
                    return BadRequest("Translation History Not Found");
                }
                return Ok(translationHistorys);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("remove")]
        public async Task<IActionResult> RemoveTranslationHistory(int id)
        {
            try
            {
                await _repository.RemoveTranslationHistory(id);
                return Ok("Translation history delete successfully"); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error " + ex.Message);
            }
        }


    }

}
