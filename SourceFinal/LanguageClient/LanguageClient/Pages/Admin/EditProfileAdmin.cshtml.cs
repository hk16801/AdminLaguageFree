using LanguageClient.DTO;
using LanguageClient.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanguageClient.Pages.Admin
{
    public class EditProfileAdminModel : PageModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public byte[] imageBytes { get; set; } = new byte[0];
        [BindProperty]
        public AddUserDTO UpdateUserDTO { get; set; } = new AddUserDTO();
        public UsersDTO temp { get; set; } = new UsersDTO();
        private readonly HttpClient _httpClient;

        public EditProfileAdminModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task OnGet()
        {

            string token = HttpContext.Session.GetString("AccessToken") ?? "";
            (UserName, UserId) = DecodeJwtToken(token);
            UpdateUserDTO.UserTempDTO = new UserTempDTO();
            UpdateUserDTO.UploadModel = new ImageUploadModel();
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/GetByAccountByID/" + UserId);

                if (response.IsSuccessStatusCode)
                {
                    temp = await response.Content.ReadFromJsonAsync<UsersDTO>();
                    HttpResponseMessage response1 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Image/" + temp.ImageUser);
                    imageBytes = await response1.Content.ReadAsByteArrayAsync();
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        IFormFile imageFile = new FormFile(memoryStream, 0, imageBytes.Length, "Image", temp.ImageUser);
                        UpdateUserDTO.UploadModel.ImageFile = imageFile;
                    }
                    UpdateUserDTO.UserTempDTO.UserId = temp.UserId;
                    UpdateUserDTO.UserTempDTO.FullName = temp.FullName;
                    UpdateUserDTO.UserTempDTO.Email = temp.Email;
                    UpdateUserDTO.UserTempDTO.Phone = temp.Phone;
                    UpdateUserDTO.UserTempDTO.Gender = temp.Gender;
                    UpdateUserDTO.UserTempDTO.DateOfBirth = temp.DateOfBirth;
                    UpdateUserDTO.UserTempDTO.National = temp.National;

                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        public async Task<IActionResult> OnPost()
        {
            if (UpdateUserDTO.UserTempDTO != null)
            {
                try
                {
                    var token = HttpContext.Session.GetString("AccessToken");
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    DateTime minDateOfBirth = new DateTime(1959, 1, 1);
                    DateTime maxDateOfBirth = new DateTime(2006, 12, 31);

                    var tempModelState = new ModelStateDictionary();

                    if (string.IsNullOrWhiteSpace(UpdateUserDTO.UserTempDTO.FullName))
                    {
                        tempModelState.AddModelError("UpdateUserDTO.UserTempDTO.FullName", "Full Name is required.");
                    }
                    if (UpdateUserDTO.UserTempDTO.Email == null || !Regex.IsMatch(UpdateUserDTO.UserTempDTO.Email, @"^(?=.{6,30}@)(?=.*[a-zA-Z])[a-zA-Z0-9]*[a-zA-Z][a-zA-Z0-9]*@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                    {
                        tempModelState.AddModelError("UpdateUserDTO.UserTempDTO.Email", "Invalid email address. Please enter a valid email address in the format and length between 6 to 30 characters.");
                    }
                    if (UpdateUserDTO.UserTempDTO.Phone == null || !Regex.IsMatch(UpdateUserDTO.UserTempDTO.Phone, @"^0[1-9][0-9]{8}$"))
                    {
                        tempModelState.AddModelError("UpdateUserDTO.UserTempDTO.Phone", "Phone number must start with '0', the second digit must not be '0' and have exactly 10 digits.");
                    }
                    if (UpdateUserDTO.UserTempDTO.DateOfBirth < minDateOfBirth || UpdateUserDTO.UserTempDTO.DateOfBirth > maxDateOfBirth)
                    {
                        tempModelState.AddModelError("UpdateUserDTO.UserTempDTO.DateOfBirth", "Date of birth must be between 1959 and 2006.");
                    }

                    if (!tempModelState.IsValid)
                    {
                        foreach (var key in tempModelState.Keys)
                        {
                            foreach (var error in tempModelState[key].Errors)
                            {
                                ModelState.AddModelError(key, error.ErrorMessage);
                            }
                        }
                        return Page();
                    }
                    DateTime dateOfBirth = UpdateUserDTO.UserTempDTO.DateOfBirth;
                    string formattedDateOfBirth = dateOfBirth.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);

                    using (var form = new MultipartFormDataContent())
                    {
                        form.Add(new StringContent(UpdateUserDTO.UserTempDTO.UserId.ToString()), "UserTempDTO.UserId");
                        form.Add(new StringContent(UpdateUserDTO.UserTempDTO.FullName), "UserTempDTO.FullName");
                        form.Add(new StringContent(UpdateUserDTO.UserTempDTO.Email), "UserTempDTO.Email");
                        form.Add(new StringContent(UpdateUserDTO.UserTempDTO.Phone), "UserTempDTO.Phone");
                        form.Add(new StringContent(UpdateUserDTO.UserTempDTO.Gender), "UserTempDTO.Gender");
                        form.Add(new StringContent(formattedDateOfBirth), "UserTempDTO.DateOfBirth");
                        form.Add(new StringContent(UpdateUserDTO.UserTempDTO.National), "UserTempDTO.National");
                        form.Add(new StringContent(UpdateUserDTO.UserTempDTO.isPickImage.ToString()), "UserTempDTO.isPickImage");
                        if (UpdateUserDTO.UploadModel == null)
                        {
                            byte[] defaultImageData = new byte[0]; // Một byte array rỗng hoặc đại diện cho hình ảnh mặc định
                            var fileContent = new StreamContent(new MemoryStream(defaultImageData));
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // Hoặc "image/png" tùy thuộc vào loại hình ảnh
                            form.Add(fileContent, "UploadModel.ImageFile", "default-image.jpg"); // Thay "default-image.jpg" bằng tên tệp ảnh mặc định
                        }
                        else
                        {
                            var fileContent = new StreamContent(UpdateUserDTO.UploadModel.ImageFile.OpenReadStream());
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue(UpdateUserDTO.UploadModel.ImageFile.ContentType);
                            form.Add(fileContent, "UploadModel.ImageFile", UpdateUserDTO.UploadModel.ImageFile.FileName);
                        }


                        HttpResponseMessage response = await _httpClient.PostAsync("http://languagefree.cosplane.asia/Users/withImage", form);

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            TempData["UpdateSuccess"] = "OK";
                        }
                        else
                        {
                            Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                            TempData["UpdateFail"] = "OK";
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return RedirectToPage("EditProfileAdmin");
        }

        private (string, string) DecodeJwtToken(string token)
        {
            string userName = "";
            string userId = "";

            if (token != null)
            {
                var tokenParts = token.Split('.');
                if (tokenParts.Length == 3)
                {
                    var base64Payload = tokenParts[1];
                    base64Payload = base64Payload.Replace('-', '+').Replace('_', '/');
                    switch (base64Payload.Length % 4)
                    {
                        case 2: base64Payload += "=="; break;
                        case 3: base64Payload += "="; break;
                    }
                    var payloadBytes = Convert.FromBase64String(base64Payload);
                    var jsonPayload = System.Text.Encoding.UTF8.GetString(payloadBytes);
                    dynamic decodedPayload = JsonConvert.DeserializeObject(jsonPayload);
                    userName = decodedPayload["UserName"];
                    userId = decodedPayload["UserID"];
                }
                else
                {
                    throw new ArgumentException("Invalid token format");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(token), "Token is null");
            }

            return (userName, userId);
        }

    }
}
