using LanguageClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace LanguageClient.Pages.UserCharts
{
    public class UsersGenderModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<Users> Users { get; private set; } = new List<Users>();
 
        [BindProperty]
        public DateTime selectDateStart { get; set; } = DateTime.Now.AddDays(-1);
        [BindProperty]
        public DateTime selectDateEnd { get; set; } = DateTime.Now;

        public int MaleCount { get; private set; }
        public int FemaleCount { get; private set; }


        public UsersGenderModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");

                if (response.IsSuccessStatusCode)
                {
                    Users = await response.Content.ReadFromJsonAsync<List<Users>>();

                    // Đếm số lượng male và female
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");
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

        public async Task<IActionResult> OnPostFilter()
        {
            if (selectDateStart > selectDateEnd)
                {
                    ModelState.AddModelError("selectDateStart", "Start date cannot be after end date.");
                    
                    // Return the page with the error message
                    return Page();
                }
       
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");

                if (response.IsSuccessStatusCode)
                {
                    Users = await response.Content.ReadFromJsonAsync<List<Users>>();
                    Users = Users.Where(u => u.Timestamp.Date > selectDateStart && u.Timestamp.Date < selectDateEnd).ToList();
                    // Đếm số lượng male và female
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");

                }
                else
                {
                    Users = new List<Users>();
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Users = new List<Users>();
                MaleCount = Users.Count(u => u.Gender == "Male");
                FemaleCount = Users.Count(u => u.Gender == "Female");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostWeek()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");

                if (response.IsSuccessStatusCode)
                {
                    Users = await response.Content.ReadFromJsonAsync<List<Users>>();
                    Users = Users.Where(u => u.Timestamp.Date > selectDateStart && u.Timestamp.Date < selectDateEnd).ToList();
                    // Đếm số lượng male và female
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");

                }
                else
                {
                    Users = new List<Users>();
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Users = new List<Users>();
                MaleCount = Users.Count(u => u.Gender == "Male");
                FemaleCount = Users.Count(u => u.Gender == "Female");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostMonth()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");

                if (response.IsSuccessStatusCode)
                {
                    Users = await response.Content.ReadFromJsonAsync<List<Users>>();
                    Users = Users.Where(u => u.Timestamp.Date > selectDateStart && u.Timestamp.Date < selectDateEnd).ToList();
                    // Đếm số lượng male và female
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");

                }
                else
                {
                    Users = new List<Users>();
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Users = new List<Users>();
                MaleCount = Users.Count(u => u.Gender == "Male");
                FemaleCount = Users.Count(u => u.Gender == "Female");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostYear()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");

                if (response.IsSuccessStatusCode)
                {
                    Users = await response.Content.ReadFromJsonAsync<List<Users>>();
                    Users = Users.Where(u => u.Timestamp.Date > selectDateStart && u.Timestamp.Date < selectDateEnd).ToList();
                    // Đếm số lượng male và female
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");

                }
                else
                {
                    Users = new List<Users>();
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Users = new List<Users>();
                MaleCount = Users.Count(u => u.Gender == "Male");
                FemaleCount = Users.Count(u => u.Gender == "Female");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostQuarter()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");

                if (response.IsSuccessStatusCode)
                {
                    Users = await response.Content.ReadFromJsonAsync<List<Users>>();
                    Users = Users.Where(u => u.Timestamp.Date > selectDateStart && u.Timestamp.Date < selectDateEnd).ToList();
                    // Đếm số lượng male và female
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");

                }
                else
                {
                    Users = new List<Users>();
                    MaleCount = Users.Count(u => u.Gender == "Male");
                    FemaleCount = Users.Count(u => u.Gender == "Female");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Users = new List<Users>();
                MaleCount = Users.Count(u => u.Gender == "Male");
                FemaleCount = Users.Count(u => u.Gender == "Female");
            }

            return Page();
        }
      
    }
}
