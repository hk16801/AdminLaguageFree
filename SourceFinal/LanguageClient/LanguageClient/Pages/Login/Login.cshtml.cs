using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using LanguageClient.DTO;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace LanguageClient.Pages.Login
{
    public class LoginModel : PageModel
    {

        private readonly HttpClient _httpClient;

        public LoginModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public void OnGet()
        {
            try
            {
                HttpContext.Session.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                var loginData = new { Username = Username, Password = Password };
                var jsonData = JsonSerializer.Serialize(loginData);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("http://languagefree.cosplane.asia/Accounts/Login", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadFromJsonAsync<TokenReponse>();
                    if (tokenResponse.Account.RoleId == "3" || tokenResponse.Account.RoleId == "2")
                    {
                        HttpContext.Session.SetString("AccessToken", tokenResponse.AccessToken);
                        TempData["Success"] = "OK";
                        return Page();
                    }
                    else
                    {
                        TempData["Admin"] = "Admin";
                        return Page();
                    } 

                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorObject = JsonSerializer.Deserialize<Dictionary<string, string>>(errorContent);

                    if (errorObject.ContainsKey("message"))
                    {
                        if (errorObject["message"] == "UnAcc")
                        {
                            TempData["UnAcc"] = "UnAcc";
                        }
                        else if(errorObject["message"] == "Account Locked")
                        {
                            TempData["Account Locked"] = "Account Locked";
                        }
                        else if(errorObject["message"] == "Account was not Vertify")
                        {
                            TempData["Account was not Vertify"] = "Account was not Vertify";
                        }

                    }
                    else
                    {
                        TempData["Fail"] = "An error occurred while processing your request.";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return Page();


        }
    }
}