using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LanguageClient.Pages.Login
{
    public class ResetPassword : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        private readonly ILogger<ResetPassword> _logger;
        private readonly HttpClient _httpClient;

        public ResetPassword(ILogger<ResetPassword> logger , HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Accounts/ForgotPassword?username=" + Email);

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
            }catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
          return Page();
        }
    }
}