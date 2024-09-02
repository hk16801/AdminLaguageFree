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
    public class CommentsController : ControllerBase
    {
        private readonly CommentsIRepository _commentsRepository;

        public CommentsController(CommentsIRepository commentsIRepository)
        {
            _commentsRepository = commentsIRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewComments([FromBody] CommentsDTO comments)
        {
            try
            {
                await _commentsRepository.NewComments(comments);
                return Ok("Comment created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                var comments = await _commentsRepository.GetAllComments();
                if (comments == null)
                {
                    return BadRequest("Comment Not Found");
                }
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

