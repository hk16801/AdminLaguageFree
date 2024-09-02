using BusinessObject.DTO;
using BusinessObject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using Reponsitory;
using Reponsitory.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string ImageUploadPath = "images"; 
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UsersIRepository _usersrepository;
        public UsersDTO _user = new UsersDTO();
        public CheckUser check = new CheckUser();
        public Users userTemp = new Users();

        public UsersController(UsersIRepository usersIRepository, IWebHostEnvironment hostingEnvironment)
        {
            _usersrepository = usersIRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewUser(UserTempDTO model)
        {
            try
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 22);
                _user.UserId = model.UserId;
                _user.FullName = model.FullName;
                _user.ImageUser = randomNumber+".png";
                _user.Phone = model.Phone;
                _user.Gender = model.Gender;
                _user.DateOfBirth = model.DateOfBirth;
                _user.Email = model.Email;
                _user.National = model.National;                
                await _usersrepository.NewUsers(_user);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpGet("getAllUsers")]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            var users = await _usersrepository.GetAllUsers();
            if (users == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(users);
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpGet("getAllWithRole")]
        public async Task<ActionResult<List<Users>>> GetAllUserWithAccountStatus(string roleid, int status)
        {
            var user = await _usersrepository.GetAllUserWithAccountStatus(roleid, status);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpGet("getAllWithStatus")]
        public async Task<ActionResult<List<Users>>> GetAllUserWithStatus(int status)
        {
            var user = await _usersrepository.GetAllUserWithStatus(status);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }
        [HttpGet("getByUserVoice/{id}")]
        public async Task<ActionResult<UserVoiceDTO>> GetByUserVoice(int id)
        {
            var userVoice = await _usersrepository.GetByUserVoice(id);
            if (userVoice == null)
            {
                return BadRequest("User Not Found");
            }

            return Ok(userVoice);
        }
        [HttpGet("getByAccount/{username}")]
        public async Task<ActionResult<Users>> GetByAccount(string username)
        {
            var user = await _usersrepository.GetByAccount(username);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }
        [HttpGet("GetByAccountByID/{id}")]
        public async Task<ActionResult<Users>> GetByAccountByID(int id)
        {
            var user = await _usersrepository.GetByAccountByID(id);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            return Ok(user);
        }
        [HttpGet("checkUserExist/{userName}")]
        public async Task<IActionResult> CheckUserExist(string userName)
        {
            var UserExists = await _usersrepository.CheckUserExist(userName);
            check.IsChecked = UserExists;
            return Ok(check);
        }
        [HttpPost("withImage")]
        public async Task<IActionResult> UpdateUser([FromForm] AddUserDTO model)
        {
            try
            {
                userTemp = await _usersrepository.GetByUserTemp(model.UserTempDTO.UserId);
                if (model.UserTempDTO.isPickImage == true)
                {
                    if (model.UploadModel.ImageFile != null)
                    {
                        List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
                        string fileExtension = Path.GetExtension(model.UploadModel.ImageFile.FileName);
                        if (string.IsNullOrEmpty(fileExtension) || !allowedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
                        {
                            throw new Exception("Định dạng file không được hỗ trợ.");
                        }

                        string uploadPath = Path.Combine(_hostingEnvironment.ContentRootPath, ImageUploadPath);
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        string fileName = Path.GetRandomFileName() + fileExtension;
                        string filePath = Path.Combine(uploadPath, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.UploadModel.ImageFile.CopyToAsync(stream);
                        }

                        _user.ImageUser = fileName;
                    }
                    _user.UserId = model.UserTempDTO.UserId;
                    _user.FullName = model.UserTempDTO.FullName;
                    _user.Phone = model.UserTempDTO.Phone;
                    _user.Gender = model.UserTempDTO.Gender;
                    _user.DateOfBirth = model.UserTempDTO.DateOfBirth;
                    _user.Email = model.UserTempDTO.Email;
                    _user.National = model.UserTempDTO.National;
                    await _usersrepository.UpdateUsers(_user);

                    return Ok("User updated successfully");
                }
                else
                {
                    _user.UserId = model.UserTempDTO.UserId;
                    _user.ImageUser = userTemp.ImageUser;
                    _user.FullName = model.UserTempDTO.FullName;
                    _user.Phone = model.UserTempDTO.Phone;
                    _user.Gender = model.UserTempDTO.Gender;
                    _user.DateOfBirth = model.UserTempDTO.DateOfBirth;
                    _user.Email = model.UserTempDTO.Email;
                    _user.National = model.UserTempDTO.National;
                    await _usersrepository.UpdateUsers(_user);

                    return Ok("User updated without image successfully");
                }

                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

    }

}
