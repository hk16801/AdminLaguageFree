using LanguageClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace LanguageClient.Pages.Admin
{
    public class AdminManagementModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<Users> Users { get; private set; } = new List<Users>();
        public Users UserDetails { get; private set; } = new Users();
        public Users UserDelete { get; private set; } = new Users();

        public AdminManagementModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=2&status=1");



                if (response.IsSuccessStatusCode)
                {
                    Users = await response.Content.ReadFromJsonAsync<List<Users>>();

                }
                else
                {
                    Users = new List<Users>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Users = new List<Users>();
            }

            return Page();
        }

        public async Task<IActionResult> OnGetUserDetails(int userId)
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync($"http://languagefree.cosplane.asia/Users/GetByAccountByID/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    UserDetails = await response.Content.ReadFromJsonAsync<Users>();
                }
                else
                {
                    UserDetails = new Users();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                UserDetails = new Users();
            }


            return Partial("_UserDetailsPartial", UserDetails);
        }
        public async Task<IActionResult> OnGetDeleteAsync(int userId)
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.DeleteAsync($"http://languagefree.cosplane.asia/Accounts/remove/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Account deleted successfully.";
                    return Page();
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete account.";

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetEditAsync(int userId)
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync($"http://languagefree.cosplane.asia/Accounts/{userId}");

                if (response.IsSuccessStatusCode)
                {
                    var userData = await response.Content.ReadFromJsonAsync<Users>();

                    return Page();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return RedirectToPage();
        }
    }
}
