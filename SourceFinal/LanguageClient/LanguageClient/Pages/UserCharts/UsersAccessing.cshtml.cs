using LanguageClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Net.Http.Json;
using LanguageClient.DTO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace LanguageClient.Pages.UserCharts
{
    public class UsersAccessingModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<Users> Users { get; set; } = new List<Users>();
        public List<PageScreens> PageScreens { get; set; } = new List<PageScreens>();
        public List<AccessLogs> AccessLogs { get; private set; } = new List<AccessLogs>();
        public int[] MonthlyCount { get; private set; } = new int[12];
          [BindProperty]
        public DateTime selectDateStart { get; set; } = DateTime.Now.AddDays(-1);
        [BindProperty]
        public DateTime selectDateEnd { get; set; } = DateTime.Now;


        public UsersAccessingModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/AccessLogs");
                 var response1 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");
                 var response2 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Pages");

                if (response.IsSuccessStatusCode && response1.IsSuccessStatusCode && response2.IsSuccessStatusCode)
                {
                    AccessLogs = await response.Content.ReadFromJsonAsync<List<AccessLogs>>();
                    Users = await response1.Content.ReadFromJsonAsync<List<Users>>();
                    PageScreens = await response2.Content.ReadFromJsonAsync<List<PageScreens>>();

                    foreach (var accessLogs in AccessLogs)
                    {
                        int monthOfBirth = accessLogs.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData2"] = lineChartData;

                }
                else
                {
                    AccessLogs = new List<AccessLogs>();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                AccessLogs = new List<AccessLogs>();
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
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/AccessLogs");

                if (response.IsSuccessStatusCode)
                {
                    AccessLogs = await response.Content.ReadFromJsonAsync<List<AccessLogs>>();
                    AccessLogs = AccessLogs.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();

                    foreach (var accessLogs in AccessLogs)
                    {
                        int monthOfBirth = accessLogs.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData2"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                AccessLogs = new List<AccessLogs>();
                foreach (var accessLogs in AccessLogs)
                {
                    int monthOfBirth = accessLogs.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData2"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostWeekAccess()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/AccessLogs");

                if (response.IsSuccessStatusCode)
                {
                    AccessLogs = await response.Content.ReadFromJsonAsync<List<AccessLogs>>();
                    AccessLogs = AccessLogs.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();

                    foreach (var account in AccessLogs)
                    {
                        int monthOfBirth = account.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }

                    // Cập nhật dữ liệu trên biểu đồ
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData2"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                AccessLogs = new List<AccessLogs>();
                foreach (var accessLogs in AccessLogs)
                {
                    int monthOfBirth = accessLogs.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData2"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostMonthAccess()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/AccessLogs");

                if (response.IsSuccessStatusCode)
                {
                    AccessLogs = await response.Content.ReadFromJsonAsync<List<AccessLogs>>();
                    AccessLogs = AccessLogs.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();


                    foreach (var accessLogs in AccessLogs)
                    {
                        int monthOfBirth = accessLogs.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData2"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                AccessLogs = new List<AccessLogs>();
                foreach (var accessLogs in AccessLogs)
                {
                    int monthOfBirth = accessLogs.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData2"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostQuarterAccess()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/AccessLogs");

                if (response.IsSuccessStatusCode)
                {
                    AccessLogs = await response.Content.ReadFromJsonAsync<List<AccessLogs>>();
                    AccessLogs = AccessLogs.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();

                    foreach (var accessLogs in AccessLogs)
                    {
                        int monthOfBirth = accessLogs.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }

                    // Cập nhật dữ liệu trên biểu đồ
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData2"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                AccessLogs = new List<AccessLogs>();
                foreach (var accessLogs in AccessLogs)
                {
                    int monthOfBirth = accessLogs.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                // Cập nhật dữ liệu trên biểu đồ
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData2"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostYearAccess()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/AccessLogs");

                if (response.IsSuccessStatusCode)
                {
                    AccessLogs = await response.Content.ReadFromJsonAsync<List<AccessLogs>>();
                    AccessLogs = AccessLogs.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();


                    // Đếm số lượng tài khoản theo từng tháng
                    foreach (var accessLogs in AccessLogs)
                    {
                        int monthOfBirth = accessLogs.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData2"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                AccessLogs = new List<AccessLogs>();
                foreach (var accessLogs in AccessLogs)
                {
                    int monthOfBirth = accessLogs.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData2"] = lineChartData;
            }

            return Page();
        }
    }
}
