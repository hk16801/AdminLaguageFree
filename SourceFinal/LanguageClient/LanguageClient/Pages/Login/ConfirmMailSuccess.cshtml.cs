using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageClient.Pages.Login
{
    public class ConfirmMailSuccessModel : PageModel
    {
        public readonly HttpClient _httpClient;
        public ConfirmMailSuccessModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task OnGet(string id)
        {
            try {
                string trimmedId = id.Substring(30, id.Length - 60);

                var apiUrl = $"http://languagefree.cosplane.asia/Accounts/verify/{trimmedId}";

                var response = await _httpClient.PutAsync(apiUrl, null);
            } catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
           
        }
    }
}
