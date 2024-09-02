using LanguageClient.DTO;
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
    public class UsersRegistrationModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<Accounts> Accounts { get; private set; } = new List<Accounts>();
        public int[] MonthlyCount { get; private set; } = new int[12];
          [BindProperty]
        public DateTime selectDateStart { get; set; } = DateTime.Now.AddDays(-1);
        [BindProperty]
        public DateTime selectDateEnd { get; set; } = DateTime.Now;


        public UsersRegistrationModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Accounts");


                if (response.IsSuccessStatusCode)
                {
                    Accounts = await response.Content.ReadFromJsonAsync<List<Accounts>>();
                    Accounts = Accounts.Where(a => a.RoleId == "1").ToList();

                    foreach (var account in Accounts)
                    {
                        int monthOfBirth = account.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++; 
                    }
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData"] = lineChartData;

                }
                else
                {
                    Accounts = new List<Accounts>();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Accounts = new List<Accounts>();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostFilter()
        {if (selectDateStart > selectDateEnd)
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
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Accounts");

                if (response.IsSuccessStatusCode)
                {
                    Accounts = await response.Content.ReadFromJsonAsync<List<Accounts>>();
                    Accounts = Accounts.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();
                    Accounts = Accounts.Where(a => a.RoleId == "1").ToList();

                    int RoleIdOneCount = Accounts.Count();
                    ViewData["RoleIdOneCount"] = RoleIdOneCount;

                    // Đếm số lượng tài khoản theo từng tháng
                    foreach (var account in Accounts)
                    {
                        int monthOfBirth = account.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }

                    // Cập nhật dữ liệu trên biểu đồ
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                Accounts = new List<Accounts>();
                foreach (var account in Accounts)
                {
                    int monthOfBirth = account.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                // Cập nhật dữ liệu trên biểu đồ
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostWeekRegis()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Accounts");

                if (response.IsSuccessStatusCode)
                {
                    Accounts = await response.Content.ReadFromJsonAsync<List<Accounts>>();
                    Accounts = Accounts.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();
                    Accounts = Accounts.Where(a => a.RoleId == "1").ToList();

                    int RoleIdOneCount = Accounts.Count();
                    ViewData["RoleIdOneCount"] = RoleIdOneCount;

                    // Đếm số lượng tài khoản theo từng tháng
                    foreach (var account in Accounts)
                    {
                        int monthOfBirth = account.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }

                    // Cập nhật dữ liệu trên biểu đồ
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                Accounts = new List<Accounts>();
                foreach (var account in Accounts)
                {
                    int monthOfBirth = account.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                // Cập nhật dữ liệu trên biểu đồ
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostMonthRegis()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Accounts");

                if (response.IsSuccessStatusCode)
                {
                    Accounts = await response.Content.ReadFromJsonAsync<List<Accounts>>();
                    Accounts = Accounts.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();
                    Accounts = Accounts.Where(a => a.RoleId == "1").ToList();

                    int RoleIdOneCount = Accounts.Count();
                    ViewData["RoleIdOneCount"] = RoleIdOneCount;

                    // Đếm số lượng tài khoản theo từng tháng
                    foreach (var account in Accounts)
                    {
                        int monthOfBirth = account.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }

                    // Cập nhật dữ liệu trên biểu đồ
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                Accounts = new List<Accounts>();
                foreach (var account in Accounts)
                {
                    int monthOfBirth = account.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                // Cập nhật dữ liệu trên biểu đồ
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostQuarterRegis()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Accounts");

                if (response.IsSuccessStatusCode)
                {
                    Accounts = await response.Content.ReadFromJsonAsync<List<Accounts>>();
                    Accounts = Accounts.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();
                    Accounts = Accounts.Where(a => a.RoleId == "1").ToList();

                    int RoleIdOneCount = Accounts.Count();
                    ViewData["RoleIdOneCount"] = RoleIdOneCount;

                    // Đếm số lượng tài khoản theo từng tháng
                    foreach (var account in Accounts)
                    {
                        int monthOfBirth = account.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }

                    // Cập nhật dữ liệu trên biểu đồ
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                Accounts = new List<Accounts>();
                foreach (var account in Accounts)
                {
                    int monthOfBirth = account.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                // Cập nhật dữ liệu trên biểu đồ
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData"] = lineChartData;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostYearRegis()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Accounts");

                if (response.IsSuccessStatusCode)
                {
                    Accounts = await response.Content.ReadFromJsonAsync<List<Accounts>>();
                    Accounts = Accounts.Where(a => a.Timestamp.Date > selectDateStart && a.Timestamp.Date < selectDateEnd).ToList();
                    Accounts = Accounts.Where(a => a.RoleId == "1").ToList();

                    int RoleIdOneCount = Accounts.Count();
                    ViewData["RoleIdOneCount"] = RoleIdOneCount;

                    // Đếm số lượng tài khoản theo từng tháng
                    foreach (var account in Accounts)
                    {
                        int monthOfBirth = account.Timestamp.Month;
                        MonthlyCount[monthOfBirth - 1]++;
                    }

                    // Cập nhật dữ liệu trên biểu đồ
                    string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                    ViewData["LineChartData"] = lineChartData;
                }
            }
            catch (Exception ex)
            {
                Accounts = new List<Accounts>();
                foreach (var account in Accounts)
                {
                    int monthOfBirth = account.Timestamp.Month;
                    MonthlyCount[monthOfBirth - 1]++;
                }

                // Cập nhật dữ liệu trên biểu đồ
                string lineChartData = "[" + string.Join(",", MonthlyCount) + "]";
                ViewData["LineChartData"] = lineChartData;
            }

            return Page();
        }
    }
}
