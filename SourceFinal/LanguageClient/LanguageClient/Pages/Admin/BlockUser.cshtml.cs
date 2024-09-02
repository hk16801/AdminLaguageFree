using LanguageClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LanguageClient.Pages.Admin
{
    public class BlockUserModel : PageModel
    {

        private readonly HttpClient _httpClient;
        public string UserName { get; set; }
        public string UserId { get; set; }
        public List<Users> Users { get; private set; } = new List<Users>();

        public BlockUserModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGet(string status)
        {
            string token = HttpContext.Session.GetString("AccessToken") ?? "";
            (UserName, UserId) = DecodeJwtToken(token);
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                if(UserId == "3")
                {
                    var response = await _httpClient.GetAsync("https://api-languagefree.cosplane.asia/api/Users/getAllWithStatus?status=2");



                    if (response.IsSuccessStatusCode)
                    {
                        Users = await response.Content.ReadFromJsonAsync<List<Users>>();

                    }
                    else
                    {
                        Users = new List<Users>();
                    }
                }
                else
                {
                    var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=2");



                    if (response.IsSuccessStatusCode)
                    {
                        Users = await response.Content.ReadFromJsonAsync<List<Users>>();
                    }
                    else
                    {
                        Users = new List<Users>();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Users = new List<Users>();
            }

            return Page();
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
                    userId = decodedPayload["admin"];
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
