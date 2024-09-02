using BusinessObject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reponsitory.IService;
using Reponsitory.Service;
using System;
using System.Threading.Tasks;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly PagesIRepository _pagesRepository;

        public PagesController(PagesIRepository pagesRepository)
        {
            _pagesRepository = pagesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewPage([FromBody] PagesDTO page)
        {
            try
            {
                await _pagesRepository.NewPages(page);
                return Ok("Page created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPages()
        {
            try
            {
                var pages = await _pagesRepository.GetAllPages();
                if (pages == null) {
                    return BadRequest("Page Not Found");
                }
                return Ok(pages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatePage(int id, [FromBody] PagesDTO page)
        //{
        //    try
        //    {
        //        var updated = await _pagesRepository.UpdatePage(id, page);
        //        if (updated)
        //            return Ok("Page updated successfully");
        //        else
        //            return NotFound("Page not found");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}