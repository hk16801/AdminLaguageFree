using BusinessObject.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reponsitory.IService;
using System;
using System.Threading.Tasks;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RolesIRepository _repository;

        public RolesController(RolesIRepository repository)
        {
            _repository = repository;
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpPost]
        public async Task<IActionResult> CreateNewRole([FromBody] RolesDTO role)
        {
            try
            {
                await _repository.NewRoles(role);
                return Ok("Role created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _repository.GetAllRoles();
                if (roles == null)
                {
                    return BadRequest("Role Not Found");
                }
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateRole(int id, [FromBody] RolesDTO role)
        //{
        //    try
        //    {
        //        var updated = await _repository.UpdateRole(id, role);
        //        if (updated)
        //            return Ok("Role updated successfully");
        //        else
        //            return NotFound("Role not found");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
