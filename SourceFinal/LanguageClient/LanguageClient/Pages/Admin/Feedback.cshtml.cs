using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LanguageClient.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageClient.Pages.Admin
{
    public class FeedbackModel : PageModel
    {
        public readonly HttpClient _httpClient;

        public List<Comments> Comments { get; set; } = new List<Comments>();
        public List<Rates> Rates { get; set; } = new List<Rates>();
        public List<PageScreens> PageScreens { get; set; } = new List<PageScreens>();
        public List<Users> Users { get; set; } = new List<Users>();
        [BindProperty]
        public DateTime selectDateStart { get; set; } = DateTime.Now.AddDays(-1);
        [BindProperty]
        public DateTime selectDateEnd { get; set; } = DateTime.Now.AddDays(+1);

        public FeedbackModel(HttpClient httpClient)
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

        public async Task<IActionResult> OnPostFilter()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Comments");
                var response1 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Rates");
                var response2 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Pages");
                var response3 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");


                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                if (response.IsSuccessStatusCode && response1.IsSuccessStatusCode && response2.IsSuccessStatusCode && response3.IsSuccessStatusCode)
                {
                    Comments = await response.Content.ReadFromJsonAsync<List<Comments>>();
                    Rates = await response1.Content.ReadFromJsonAsync<List<Rates>>();
                    PageScreens = await response2.Content.ReadFromJsonAsync<List<PageScreens>>();
                    Users = await response3.Content.ReadFromJsonAsync<List<Users>>();
                    Comments = Comments.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();

                    ModelState["input"].RawValue = Comments = Comments.Where(c => c.PageId == 4).ToList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching : {ex.Message}");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostWeek()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Comments");
                var response1 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Rates");
                var response2 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Pages");
                var response3 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");


                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                if (response.IsSuccessStatusCode && response1.IsSuccessStatusCode && response2.IsSuccessStatusCode && response3.IsSuccessStatusCode)
                {
                    Comments = await response.Content.ReadFromJsonAsync<List<Comments>>();
                    Rates = await response1.Content.ReadFromJsonAsync<List<Rates>>();
                    PageScreens = await response2.Content.ReadFromJsonAsync<List<PageScreens>>();
                    Users = await response3.Content.ReadFromJsonAsync<List<Users>>();
                    Comments = Comments.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching : {ex.Message}");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSearch(string pageName)
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
                    if (!string.IsNullOrEmpty(pageName))
                    {
                        PageScreens = PageScreens.Where(p => p.PageName.Contains(pageName, StringComparison.OrdinalIgnoreCase)).ToList();
                      
                        var pageIds = PageScreens.Select(p => p.PageId).ToList();
                     
                        Comments = Comments.Where(c => pageIds.Contains(c.PageId)).ToList();
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
