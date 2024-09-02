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
using Repository.IService;
using DataAccess.DAO;
using System.Web;
using MailKit;
using System.Linq;

namespace Admin_LanguageFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private HashSet<string> _revokedTokens = new HashSet<string>();
        private readonly AccountsIRepository _accountsRepository;
        private readonly IEmailRepository _emailRepository;
        public UserSessionResponse _userSessionResponse = new UserSessionResponse();
        public CheckAccount check = new CheckAccount();
        public AccountsController(AccountsIRepository accountsIRepository, IEmailRepository emailRepository)
        {
            _accountsRepository = accountsIRepository;
            _emailRepository = emailRepository;
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
        [Authorize(Policy = IdentifyRole.Match)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccounts(int id, [FromBody] ChangePasswordDTO accounts)
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
                return StatusCode(500, "Internal server error" +ex.Message);
            }
        }
        [Authorize(Policy = IdentifyRole.Match)]
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
        [Authorize(Policy = IdentifyRole.Match)]
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
        [AllowAnonymous]        
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
                return BadRequest(new { Message = "Account Locked" });
            }
            else if (acc.isVerify == false)
            {
                return BadRequest(new { Message = "Account was not Vertify" });
            }
            TokenReponse tokenReponse = new TokenReponse();
           
            if (check)
            {
                var token = GenerateToken(acc);
                tokenReponse.Account = acc;
                tokenReponse.AccessToken = token;
                return Ok(tokenReponse);
            }
            else
            {
                return BadRequest(new { Message = "Invalid login credentials" });
            }
        }
        private string GenerateRandomString(Random rnd, int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        [HttpPost("regist")]
        public async Task<IActionResult> RegistAdmin([FromBody] RegistAdminDTO accounts)
        {
            try
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 7);
                accounts.ImageUser = randomNumber + ".png";
                await _accountsRepository.RegistAdmin(accounts);
                var newAccountId = _accountsRepository.GetAccountsToSession(accounts.Username);
                var Fname = accounts.FullName;
                int id = newAccountId.Result;
                string randomString1 = GenerateRandomString(rnd, 30); // Sử dụng biến rnd để tạo chuỗi ngẫu nhiên
                string randomString2 = GenerateRandomString(rnd, 30); // Sử dụng biến rnd để tạo chuỗi ngẫu nhiên
                string redirectUrl = $"http://languagefree.cosplane.asia/Login/ConfirmMailSuccess?id={randomString1}{id}{randomString2}";

                var ml = new MailContent
                {
                    Subject = "Register! Verified Mail",
                    To = accounts.Username,
                    Body = $@"
             <!DOCTYPE html>
                <html>

                <head>
                    <meta charset=""utf-8"">
                    <meta http-equiv=""x-ua-compatible"" content=""ie=edge"">
                    <title>Email Confirmation</title>
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                    <link href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700&display=swap"" rel=""stylesheet""/>

                </head>

                <body style=""background-color: #e9ecef;"">
 
                    <div class=""preheader""
                        style=""display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;"">
                        A preheader is the short summary text that follows the subject line when an email is viewed in the inbox.
                    </div>

                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin-top: 50px;"">

                        <tr>
                            <td align=""center"" bgcolor=""#e9ecef"">

                            </td>
                        </tr>

                        <tr>
                            <td align=""center"" bgcolor=""#e9ecef"">
                                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;margin-top: 50px"""">
                                    <tr>
                                        <td align=""right"" bgcolor=""#ffffff"" style=""padding:10px 20px; margin-top: 100px;"">
                                            <a  target=""_blank""
                                                style=""display: inline-block;"">
                                                <img src=""http://api-languagefree.cosplane.asia/api/Image/logomail.jpg""
                                                    alt=""Logo"" border=""0"" width=""48""
                                                    style=""display: block;display: block;width: 130px;max-width: 130px;"">
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                                    <tr>
                                        <td align=""left"" bgcolor=""#ffffff""
                                            style=""padding: 36px 24px 0; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; border-top: 0px solid #d4dadf;"">
                                            <h1
                                                style=""margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;"">
                                                Confirm Your Email Address</h1>
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td align=""center"" bgcolor=""#e9ecef"">
                                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">

                                    <tr>
                                        <td align=""left"" bgcolor=""#ffffff""
                                            style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;"">
                                            <p style=""margin: 0;"">Tap the button below to confirm your email address. If you didn't
                                                logged in to <b style=""color:#193978;"">Language Free</b>'s management page, you can
                                                safely delete this email.</p>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align=""left"" bgcolor=""#ffffff"">
                                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                                <tr>
                                                    <td align=""center"" bgcolor=""#ffffff"" style=""padding: 12px;"">
                                                        <table border=""0"" cellpadding=""0"" cellspacing=""0"">
                                                            <tr>
                                                                <td align=""center"" bgcolor=""#193978"" style=""border-radius: 6px;"">
                                                            <a href=""{redirectUrl}"" rel=""noreferrer"" style=""display: inline-block; padding: 12px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;"">Verify Email Address</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                
                                    <tr>
                                        <td align=""left"" bgcolor=""#ffffff""
                                            style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf"">
                                            <p style=""margin: 0;"">Cheers, <br>NameTextUser</p>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                            <tr>
                                <td align=""center"" bgcolor=""#e9ecef"" style=""padding: 24px;"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                                        <tr>
                                            <td align=""center"" bgcolor=""#e9ecef"" style=""padding: 12px 24px; font-family: ""Source Sans Pro"", Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px; color: #666;"">
                                                <p style=""margin: 0;"">You received this email because we received a request for [Login] for your account. If you didn't request [Login] you can safely delete this email.</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align=""center"" bgcolor=""#e9ecef"" style=""padding: 12px 24px; font-family: ""Source Sans Pro"", Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px; color: #666;"">
                                                <p style=""margin: 0;"">Languagefree_management@gmail.com | Can Tho, Viet Nam</p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>"
                };
                ml.Body = ml.Body.Replace("NameTextUser", Fname);
                _emailRepository.SendMail(ml);
                return Ok("Admin registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
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
        [HttpGet("checkAccountExist/{username}")]
        public async Task<IActionResult> CheckAccountExist(string username)
        {
            var accountExists = await _accountsRepository.CheckAccountExist(username);
            check.IsChecked = accountExists;
            return Ok(check);
        }
        [Authorize(Policy = IdentifyRole.Match)]
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
        [Authorize(Policy = IdentifyRole.Match)]
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
        [HttpPut("verify/{id}")]
        public async Task<IActionResult> VerifyAccount(int id)
        {
            try
            {
                await _accountsRepository.VerifyAccount(id);
                return Ok("Account verify successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string username)
        {
            try
            {
                string newpass = await _accountsRepository.ForgotPassword(username);

                MailContent mailContent = new MailContent()
                {
                    Subject = "ForgotPassword! Please sign in again!",
                    To = username,
                    Body = "<!DOCTYPE html>\r\n<html>\r\n\r\n<head>\r\n " +
                            " <meta charset=\"utf-8\">\r\n " +
                            " <meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">\r\n " +
                            " <title>Email Confirmation</title>\r\n " +
                            " <meta name=\"viewport\" content=\"width=device-widt1h, initial-scale=1\">\r\n "+
                            " <link href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700&display=swap\" rel=\"stylesheet\"/>\r\n " +
                            " </head>\r\n " +
                            " <body style=\"background-color: #e9ecef;\">\r\n " +
                            " <div class=\"preheader\" style=\"display: none; max-width: 0;max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;\">\r\n " +
                            " A preheader is the short summary text that follows the subject line when an email is viewed in the inbox.</div>\r\n " +
                            " <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"margin-top: 50px;\">\r\n " +
                            " <tr>\r\n<td align=\"center\" bgcolor=\"#e9ecef\">\r\n\r\n</td>\r\n</tr>\r\n " +
                            " <tr>\r\n<td align=\"center\" bgcolor=\"#e9ecef\">\r\n\r\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;margin-top: 50px\"\">\r\n " +
                            " <tr>\r\n<td align=\"right\" bgcolor=\"#ffffff\" style=\"padding:10px 20px; margin-top: 100px;\">\r\n " +
                            " <a  target=\"_blank\" style=\"display: inline-block;\">\r\n\r\n<img src=\"http://api-languagefree.cosplane.asia/api/Image/logomail.jpg\" alt=\"Logo\" border=\"0\" width=\"48\" style=\"display: block;display: block;width: 130px;max-width: 130px;\">\r\n</a>\r\n " +
                            " </td>\r\n</tr>\r\n\r\n</table>\r\n " +
                            " <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n " +
                            " <tr>\r\n<td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 36px 24px 0; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; border-top: 0px solid #d4dadf;\">\r\n " +
                            " <h1 style=\"margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;\">Password Reset Request Successful</h1>\r\n " +
                            " </td>\r\n</tr>\r\n\r\n</table>\r\n</td>\r\n\r\n</tr>\r\n " +
                            " <tr>\r\n<td align=\"center\" bgcolor=\"#e9ecef\">\r\n " +
                            " <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n " +
                            " <tr>\r\n<td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n " +
                            " <p style=\"margin: 0;\">Your password has been successfully changed. You can now use your new password to access your account. If you didn't log in to <b style=\"color:#193978;\">Language Free</b>'s management page, you can safely delete this email.</p>\r\n " +
                            " </td>\r\n</tr>\r\n\r\n<tr>\r\n " +
                            " <td align=\"left\" bgcolor=\"#ffffff\">\r\n " +
                            " <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">\r\n<tr>\r\n " +
                            " <td align=\"center\" bgcolor=\"#ffffff\" style=\"padding: 12px;\">\r\n " +
                            " <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n<tr>\r\n " +
                            " <td align=\"center\" bgcolor=\"#193978\" style=\"border-radius: 6px;\"> " +
                            " <strong style=\"display: inline-block; padding: 12px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;\">" + newpass +@"</strong> " +
                            " </td>\r\n</tr>\r\n\r\n</table>\r\n</td>\r\n\r\n</tr>\r\n</table>\r\n\r\n</td>\r\n</tr>\r\n " +
                            " <tr>\r\n<td align=\"left\" bgcolor=\"#ffffff\" style=\"padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf\">\r\n " +
                            " </td>\r\n</tr>\r\n\r\n</table>\r\n</td>\r\n\r\n</tr>\r\n<tr>\r\n " +
                            " <td align=\"center\" bgcolor=\"#e9ecef\" style=\"padding: 24px;\">\r\n " +
                            " <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"max-width: 600px;\">\r\n " +
                            " <tr>\r\n<td align=\"center\" bgcolor=\"#e9ecef\" style=\"padding: 12px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px; color: #666;\">\r\n " +
                            " <p style=\"margin: 0;\">You received this email because we received a request for [Login] for your account. If you didn't request [Login] you can safely delete this email.</p>\r\n " +
                            " </td>\r\n</tr>\r\n\r\n<tr>\r\n " +
                            " <td align=\"center\" bgcolor=\"#e9ecef\" style=\"padding: 12px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px; color: #666;\">\r\n " +
                            " <p style=\"margin: 0;\">Languagefree_management@gmail.com | Can Tho, Viet Nam</p>\r\n " +
                            " </td>\r\n</tr>\r\n\r\n</table>\r\n</td>\r\n\r\n</tr>\r\n</table>\r\n\r\n</body>\r\n</html>\r\n "
                };

                mailContent.Body = mailContent.Body.Replace("{{newpass}}", newpass);
                _emailRepository.SendMail(mailContent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
