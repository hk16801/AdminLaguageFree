using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using LanguageClient.DTO;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LanguageClient.Pages.Admin
{
    public class CreateAdmin : PageModel
    {
        private readonly ILogger<CreateAdmin> _logger;
        private readonly HttpClient _httpClient;

        [BindProperty]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [BindProperty]
        public string Gender { get; set; }

        [BindProperty]
        [Display(Name = "Preferred Language")]
        public string Language { get; set; }

        public CreateAdmin(ILogger<CreateAdmin> logger, HttpClient httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                DateTime minDateOfBirth = new DateTime(1959, 1, 1);
                DateTime maxDateOfBirth = new DateTime(2006, 12, 31);
                var tempModelState = new ModelStateDictionary();
                if (string.IsNullOrWhiteSpace(FullName))
                {
                    ModelState.AddModelError("FullName", "Please enter your full name.");
                }

                if (string.IsNullOrWhiteSpace(Email))
                {
                    ModelState.AddModelError("Email", "Please enter your email address.");
                }

                if (string.IsNullOrWhiteSpace(Password))
                {
                    ModelState.AddModelError("Password", "Please enter your password.");
                }

                if (string.IsNullOrWhiteSpace(PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "Please enter your phone number.");
                }

                if (string.IsNullOrWhiteSpace(Gender))
                {
                    ModelState.AddModelError("Gender", "Please select your gender.");
                }

                if (string.IsNullOrWhiteSpace(Language))
                {
                    ModelState.AddModelError("Language", "Please select your preferred language.");
                }

                // Kiểm tra điều kiện khác và thêm lỗi vào ModelState
                if (!Regex.IsMatch(Email, @"^(?=.{6,30}@)(?=.*[a-zA-Z])[a-zA-Z0-9]*[a-zA-Z][a-zA-Z0-9]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    ModelState.AddModelError("Email", "Invalid email format.");
                }

                if (!Regex.IsMatch(PhoneNumber, @"^0[1-9][0-9]{8}$"))
                {
                    ModelState.AddModelError("PhoneNumber", "Phone number must start with '0', the second digit must not be '0' and have exactly 10 digits.");
                }

                if (DateOfBirth < minDateOfBirth || DateOfBirth > maxDateOfBirth)
                {
                    ModelState.AddModelError("DateOfBirth", "Date of birth must be between 1959 and 2006.");
                }

                if (!ModelState.IsValid)
                {
                    // Trở về trang hiện tại nếu có lỗi
                    return Page();
                }
                var data = new
                {
                    username = Email,
                    password = Password,
                    fullName = FullName,
                    imageUser = "",
                    phone = PhoneNumber,
                    dateOfBirth = DateOfBirth.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    gender = Gender,
                    national = Language
                };
                var jsonRequest = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://languagefree.cosplane.asia/Accounts/regist", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "OK";
                    return Page();
                }
                else
                {
                    TempData["Fail"] = "OK";
                    return Page();
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
