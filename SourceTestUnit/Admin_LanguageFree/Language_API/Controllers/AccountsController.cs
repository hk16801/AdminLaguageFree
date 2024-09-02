using System.Net;
using BusinessObject.DTO;
using BusinessObject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using Reponsitory;
using Reponsitory.Service;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private HashSet<string> _revokedTokens = new HashSet<string>();
        private readonly AccountsIRepository _accountsRepository;
        public UserSessionResponse _userSessionResponse = new UserSessionResponse();
        public CheckAccount check = new CheckAccount();
        public AccountsController(AccountsIRepository accountsIRepository)
        {
            _accountsRepository = accountsIRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAccounts([FromBody] AccountsDTO accounts)
        {
            try
            {
                await _accountsRepository.NewAccounts(accounts);
                return Ok("Account created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccounts(int id, [FromBody] AccountsDTO accounts)
        {
            try
            {
                var updated = await _accountsRepository.UpdateAccounts(id, accounts);
                if (updated)
                    return Ok("Accounts updated successfully");
                else
                    return NotFound("Accounts not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountsRepository.GetAllAccounts();
                if (accounts == null)
                {
                    return BadRequest("Account Not Found");
                }    
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("status")]
        public async Task<IActionResult> GetAllAccountsWithStatusTwo(int status)
        {
            try
            {
                var accounts = await _accountsRepository.GetAllAccountsWithStatus(status);

                if (accounts == null)
                {
                    return BadRequest("Account Not Found");
                }
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //[HttpPost]
        //[Route("Logout")]
        //public IActionResult Logout([FromBody] String accesstoken)
        //{
        //    if (string.IsNullOrEmpty(accesstoken))
        //    {
        //        return BadRequest("Token is required.");
        //    }
        //    // Thêm token vào danh sách token đã hủy
        //    _revokedTokens.Add(accesstoken);
        //    return Ok("Token revoked successfully.");
        //}
        //[HttpGet]
        //public IActionResult Protected()
        //{
        //    var token = HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1]; // Lấy token từ header của request
        //    if (_revokedTokens.Contains(token))
        //    {
        //        return Unauthorized("Token has been revoked. Please login again.");
        //    }

        //    return Ok("This is a protected resource.");
        //}

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> CheckLogin(LoginDTO login)
        {
            bool check = await _accountsRepository.CheckLogin(login.Username, login.Password);
            var acc = await _accountsRepository.GetAccountsToToken(login.Username);
            if (acc == null || !check)
            {
                return BadRequest(new { Message = "UnAcc" });
            }
            else if(acc.Status == 2)
            {
                return BadRequest(new { Message = "Account Locket" });
            }
            TokenReponse tokenReponse = new TokenReponse();
                var token = GenerateToken(acc);
                tokenReponse.Account = acc;
                tokenReponse.AccessToken = token;
                return Ok(tokenReponse);
            
        }
        private string GenerateToken(Accounts acc)
        {
            var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet."));
            var credentials = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);
            var claim = new[]
            {
                new Claim ("UserName", acc.Username),
                new Claim ("UserID", acc.UserId.ToString()),
                new Claim ("admin", acc.RoleId.ToString()),
                new Claim ("AccountId", acc.AccountId.ToString())
            };
            var token = new JwtSecurityToken
                (
                issuer: "issuer",
                audience: "audience",
                claim,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
                );
            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
        [HttpGet("getAccountsToSession/{username}")]
        public async Task<IActionResult> GetAccountsToSession(string username)
        {
            var userId = await _accountsRepository.GetAccountsToSession(username);
            _userSessionResponse.UserId = userId;
            return Ok(_userSessionResponse);
        }
        [Authorize(Policy = IdentifyRole.AdminRole)]
        [HttpGet("checkAccountExist/{username}")]
        public async Task<IActionResult> CheckAccountExist(string username)
        {
            var accountExists = await _accountsRepository.CheckAccountExist(username);
            check.IsChecked = accountExists;
            return Ok(check);
        }
        [HttpPut("remove/{id}")]
        public async Task<IActionResult> RemoveAccount(int id)
        {
            try
            {
                await _accountsRepository.RemoveAccount(id);
                return Ok("Account delete successfully"); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("active/{id}")]
        public async Task<IActionResult> ActiveAccount(int id)
        {
            try
            {
                await _accountsRepository.ActiveAccount(id);
                return Ok("Account active successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
