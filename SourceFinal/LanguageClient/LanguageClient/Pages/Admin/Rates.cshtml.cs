using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Threading.Tasks;
using LanguageClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace LanguageClient.Pages.Admin
{
    public class RatesModel : PageModel
    {
        public readonly HttpClient _httpClient;

        public List<Comments> Comments { get; set; } = new List<Comments>();
        public List<Rates> Rates { get; set; } = new List<Rates>();
        public List<PageScreens> PageScreens { get; set; } = new List<PageScreens>();
        public List<Users> Users { get; set; } = new List<Users>();

        public RatesModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Comments");
                var response1 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Rates");
                var response2 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Pages");
                var response3 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");



                if (response.IsSuccessStatusCode && response1.IsSuccessStatusCode && response2.IsSuccessStatusCode && response3.IsSuccessStatusCode)
                {
                    Comments = await response.Content.ReadFromJsonAsync<List<Comments>>();
                    Rates = await response1.Content.ReadFromJsonAsync<List<Rates>>();
                    PageScreens = await response2.Content.ReadFromJsonAsync<List<PageScreens>>();
                    Users = await response3.Content.ReadFromJsonAsync<List<Users>>();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching : {ex.Message}");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostSearch(string fullName)
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Pages");
                var responseComments = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Comments");

                var response1 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Rates");
                var response2 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Pages");
                var response3 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");

                if (response.IsSuccessStatusCode && responseComments.IsSuccessStatusCode && response1.IsSuccessStatusCode && response2.IsSuccessStatusCode && response3.IsSuccessStatusCode)
                {
                    Comments = await responseComments.Content.ReadFromJsonAsync<List<Comments>>();
                    Rates = await response1.Content.ReadFromJsonAsync<List<Rates>>();
                    PageScreens = await response2.Content.ReadFromJsonAsync<List<PageScreens>>();
                    Users = await response3.Content.ReadFromJsonAsync<List<Users>>();
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        Users = Users.Where(u => u.FullName.Contains(fullName, StringComparison.OrdinalIgnoreCase)).ToList();
                        var userIds = Users.Select(p => p.UserId).ToList();
                        Rates = Rates.Where(c => userIds.Contains(c.UserId)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching data: {ex.Message}");
            }

            return Page();
        }
    }
}