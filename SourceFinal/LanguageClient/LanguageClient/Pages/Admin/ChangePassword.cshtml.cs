using LanguageClient.DTO;
using LanguageClient.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanguageClient.Pages.Admin
{
    public class ChangePassword : PageModel
    {

        private readonly HttpClient _httpClient;

        [BindProperty]
        [Required(ErrorMessage = "Please enter your Current Password.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your New Password.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your Confirm Password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }



        public ChangePassword(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NewPassword != ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "The new password and confirm password must match.");
                return Page();
            }
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                (UserName, UserId) = DecodeJwtToken(token);
                var json = JsonConvert.SerializeObject(new
                {
                    currentPassword = CurrentPassword,
                    newPassword = NewPassword,
                    confirmPassword = ConfirmPassword
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.PutAsync("http://languagefree.cosplane.asia/Accounts/" + UserId, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    TempData["Success"] = "OK";
                    return Page();
                }
                else 
                {
                    TempData["BB"] = "OK";
                    return Page();
                 
                }
            }
            catch (Exception ex)
            {
                TempData["Fail"] = "OK";
                return Page();
            }
        }
        private (string, string) DecodeJwtToken(string token)
        {
            string userName = "";
            string userId = "";

            if (token != null)
            {
                var tokenParts = token.Split('.');
                if (tokenParts.Length == 3)
                {
                    var base64Payload = tokenParts[1];
                    base64Payload = base64Payload.Replace('-', '+').Replace('_', '/');
                    switch (base64Payload.Length % 4)
                    {
                        case 2: base64Payload += "=="; break;
                        case 3: base64Payload += "="; break;
                    }
                    var payloadBytes = Convert.FromBase64String(base64Payload);
                    var jsonPayload = System.Text.Encoding.UTF8.GetString(payloadBytes);
                    dynamic decodedPayload = JsonConvert.DeserializeObject(jsonPayload);
                    userName = decodedPayload["UserName"];
                    userId = decodedPayload["UserID"];
                }
                else
                {
                    throw new ArgumentException("Invalid token format");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(token), "Token is null");
            }

            return (userName, userId);
        }
    }
}