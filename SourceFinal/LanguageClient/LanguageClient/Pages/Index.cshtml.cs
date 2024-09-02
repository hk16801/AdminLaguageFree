using LanguageClient.DTO;
using LanguageClient.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;



namespace LanguageClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;
        public string UserName { get; set; }
        public string UserId { get; set; }
        public byte[] imageBytes { get; set; } = new byte[0];
        [BindProperty]
        public AddUserDTO UpdateUserDTO { get; set; } = new AddUserDTO();
        public UsersDTO temp { get; set; } = new UsersDTO();
        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public List<Rates> Rates { get; private set; } = new List<Rates>();
        public List<PageScreens> PageScreens { get; private set; } = new List<PageScreens>();

        public int TotalUserIds { get; set; }
        public int TotalAccessLogsIds { get; set; }
        public int TotalCommentsIds { get; set; }
        public int TotalRatesIds { get; set; }
        public double AverageRateIds { get; set; }
        public int NumberRatesIds { get; set; }
        public int RateNum { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public double MalePercentage { get; set; }
        public double FemalePercentage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Adolescent_Percentage { get; set; }
        public double Young_Percentage { get; set; }
        public double Adult_Percentage { get; set; }
        public double Middle_Percentage { get; set; }
        public double Elderly_Percentage { get; set; }
        public int Most_Used_Id { get; set; }
        public int Second_Used_Id { get; set; }
        public int Third_Used_Id { get; set; }
        public string Most_Used_Name { get; set; }
        public string Second_Used_Name { get; set; }
        public string Third_Used_Name { get; set; }
        public double Most_Used_Percentage { get; set; }
        public double Second_Used_Percentage { get; set; }
        public double Third_Used_Percentage { get; set; }
        public List<AccessLogs> AccessLogsList { get; private set; } = new List<AccessLogs>();
        public DateTime Earliest_Usage_Date { get; set; }
        public DateTime Latest_Usage_Date { get; set; }
        public DateTime Mid_Usage_Date { get; set; }
        public DateTime Date { get; set; }
        public int EarliestMostUsedId { get; set; }
        public int LatestMostUsedId { get; set; }
        public int MidMostUsedId { get; set; }
        public int EarliestSecondUsedId { get; set; }
        public int LatestSecondUsedId { get; set; }
        public int MidSecondUsedId { get; set; }
        public int EarliestThirdUsedId { get; set; }
        public int LatestThirdUsedId { get; set; }
        public int MidThirdUsedId { get; set; }

        public List<Users> Top5NewUsers { get; private set; } = new List<Users>();

        public List<Users> Users { get; private set; } = new List<Users>();
        public List<Users> UsersTop5Real { get; private set; } = new List<Users>();
        public List<Comments> Top5Comments { get; private set; } = new List<Comments>();
        public Dictionary<string, int> UserActivityCount { get; set; }
        public List<AccessLogs> AccessLogs { get; private set; } = new List<AccessLogs>();
        public List<LanguageLogs> LanguageLogs { get; private set; } = new List<LanguageLogs>();
        public List<Users> RemainingUsers { get; private set; } = new List<Users>();
        public List<Comments> Comments { get; set; } = new List<Comments>();
        // Phương thức để lấy dữ liệu từ API
        private async Task<List<T>> GetDataFromApiAsync<T>(string apiUrl)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<T>>();
            }
            return null;
        }
        //Hàm lấy tổng các giá trị
        private int GetTotalCount<T>(List<T> data)
        {
            return data != null ? data.Count : 0;
        }

        //Hàm tish trung bình số sao
        private void CalculateAverageRateIds()
        {
            if (Rates != null && Rates.Count > 0)
            {
                NumberRatesIds = Rates.Select(r => r.RateNum).Sum();
                double rawAverage = (double)NumberRatesIds / TotalRatesIds;
                double fraction = rawAverage - Math.Truncate(rawAverage);

                if (fraction < 0.25 || (fraction >= 0.25 && fraction < 0.75 && rawAverage != 4.4))
                {
                    AverageRateIds = Math.Round(rawAverage, 1, MidpointRounding.AwayFromZero);
                }
                else if (fraction >= 0.75 || (fraction >= 0.25 && fraction < 0.75 && rawAverage == 4.4))
                {
                    AverageRateIds = Math.Ceiling(rawAverage * 2) / 2;
                }
            }
            else
            {
                NumberRatesIds = 0;
                AverageRateIds = 0;
                RateNum = 0;
            }
        }


        //Hàm phân tích giới tính người dùng
        private void CalculateUserGenderStatistics()
        {
            foreach (var user in Top5NewUsers)
            {
                if (user.Gender == "Male")
                    Male++;
                else if (user.Gender == "Female")
                    Female++;
            }

            if (TotalUserIds > 0)
            {
                MalePercentage = Math.Round((double)Male / TotalUserIds * 100, 1);
                FemalePercentage = Math.Round((double)Female / TotalUserIds * 100, 1);
            }
            else
            {
                MalePercentage = 0;
                FemalePercentage = 0;
            }
        }

        //Hàm phân tích độ tuổi người dùng
        public void CalculateUserAgeStatistics()
        {
            int adolescentCount = 0;
            int youngCount = 0;
            int adultCount = 0;
            int middleCount = 0;
            int elderlyCount = 0;

            foreach (var user in Top5NewUsers)
            {
                int age = CalculateAge(user.DateOfBirth);

                if (age >= 7 && age <= 24)
                {
                    adolescentCount++;
                }
                else if (age >= 25 && age <= 34)
                {
                    youngCount++;
                }
                else if (age >= 35 && age <= 44)
                {
                    adultCount++;
                }
                else if (age >= 45 && age <= 56)
                {
                    middleCount++;
                }
                else if (age > 56)
                {
                    elderlyCount++;
                }
            }
            Adolescent_Percentage = Math.Round((double)adolescentCount / TotalUserIds * 100, 1);
            Young_Percentage = Math.Round((double)youngCount / TotalUserIds * 100, 1);
            Adult_Percentage = Math.Round((double)adultCount / TotalUserIds * 100, 1);
            Middle_Percentage = Math.Round((double)middleCount / TotalUserIds * 100, 1);
            Elderly_Percentage = Math.Round((double)elderlyCount / TotalUserIds * 100, 1);
        }

        //Hàm tính tuổi người dùng từ dữ liệu DateOfBirth
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - dateOfBirth.Year;

            if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
            {
                age--;
            }
            return age;
        }

        //Id of Most Function
        private void CalculateMostFrequentPage()
        {
            // Tạo một từ điển để đếm số lần xuất hiện của mỗi pageId
            Dictionary<int, int> pageIdCount = new Dictionary<int, int>();

            // Các PageId mà bạn muốn loại bỏ
            List<int> excludedPageIds = new List<int> { 1, 2, 3, 4, 10, 12 };

            foreach (var accessLog in AccessLogs)
            {
                int pageId = accessLog.PageId;

                // Kiểm tra xem PageId có nằm trong danh sách cần loại bỏ không
                if (!excludedPageIds.Contains(pageId))
                {
                    // Nếu không, thêm hoặc tăng số lần xuất hiện của PageId trong từ điển
                    if (pageIdCount.ContainsKey(pageId))
                    {
                        pageIdCount[pageId]++;
                    }
                    else
                    {
                        pageIdCount[pageId] = 1;
                    }
                }
            }

            // Tiếp tục xử lý giống như trước đó
            var sortedPageIdCount = pageIdCount.OrderByDescending(x => x.Value).ToList();
            Most_Used_Id = sortedPageIdCount.FirstOrDefault().Key;
            Most_Used_Name = GetPageNameById(Most_Used_Id);
            if (sortedPageIdCount.Count >= 2)
            {
                Second_Used_Id = sortedPageIdCount[1].Key;
                Second_Used_Name = GetPageNameById(Second_Used_Id);
            }
            else
            {
                Second_Used_Id = -1;
                Second_Used_Name = "N/A";
            }
            if (sortedPageIdCount.Count >= 3)
            {
                Third_Used_Id = sortedPageIdCount[2].Key;
                Third_Used_Name = GetPageNameById(Third_Used_Id);
            }
            else
            {
                Second_Used_Id = -1;
                Second_Used_Name = "N/A";
            }
        }
        //Id to Name of Most Function
        private string GetPageNameById(int pageId)
        {
            Dictionary<int, string> pageIdToNameMapping = new Dictionary<int, string>
                {
                    { 1, "Intro Screen" },
                    { 2, "Login SDT" },
                    { 3, "Login Gmail" },
                    { 4, "Home" },
                    { 5, "Translate Text" },
                    { 6, "Translate Speech" },
                    { 7, "Translate Image" },
                    { 8, "News" },
                    { 9, "Weather" },
                    { 10, "Weather Detail" },
                    { 11, "Profile" },
                    { 12, "Welcome" },
                    { 13, "About Us" },
                    { 14, "Chat Bot" },
                    { 15, "Help" },
                    { 16, "QR Scan" },
                    { 17, "User Guide" },
                    { 18, "Favourite" },
                };
            if (pageIdToNameMapping.ContainsKey(pageId))
                return pageIdToNameMapping[pageId];
            else
                return "Unknown";
        }

        //Phần trăm của các function sử dụng nhiều nhất
        private void CalculatePageAccessPercentages()
        {
            // Tạo một từ điển để đếm số lần xuất hiện của mỗi pageId
            Dictionary<int, int> pageIdCount = new Dictionary<int, int>();

            // Các PageId mà bạn muốn loại bỏ
            List<int> excludedPageIds = new List<int> { 1, 2, 3, 4, 10, 12 };

            foreach (var accessLog in AccessLogs)
            {
                int pageId = accessLog.PageId;

                // Kiểm tra xem PageId có nằm trong danh sách cần loại bỏ không
                if (!excludedPageIds.Contains(pageId))
                {
                    // Nếu không, thêm hoặc tăng số lần xuất hiện của PageId trong từ điển
                    if (pageIdCount.ContainsKey(pageId))
                    {
                        pageIdCount[pageId]++;
                    }
                    else
                    {
                        pageIdCount[pageId] = 1;
                    }
                }
            }
            var sortedPageIdCount = pageIdCount.OrderByDescending(x => x.Value).ToList();
            int totalAccesses = sortedPageIdCount.Sum(x => x.Value);
            double mostPercentage = sortedPageIdCount.Count > 0 ? (double)sortedPageIdCount[0].Value / totalAccesses * 100 : 0;
            double secondPercentage = sortedPageIdCount.Count > 1 ? (double)sortedPageIdCount[1].Value / totalAccesses * 100 : 0;
            double thirdPercentage = sortedPageIdCount.Count > 2 ? (double)sortedPageIdCount[2].Value / totalAccesses * 100 : 0;
            Most_Used_Percentage = Math.Round(mostPercentage, 1);
            Second_Used_Percentage = Math.Round(secondPercentage, 1);
            Third_Used_Percentage = Math.Round(thirdPercentage, 1);
        }

        //Thời gian của các hàm sử dụng nhiều nhất
        private void GetUsageTimePeriod()
        {
            if (AccessLogs == null || AccessLogs.Count == 0)
            {
                Earliest_Usage_Date = DateTime.MinValue;
                Mid_Usage_Date = DateTime.MinValue;
                Latest_Usage_Date = DateTime.MinValue;
                return;
            }

            DateTime earliestDate = AccessLogs.Min(x => x.Timestamp.Date);
            DateTime latestDate = AccessLogs.Max(x => x.Timestamp.Date);

            // Kiểm tra xem ngày đầu tiên và ngày cuối cùng có giống nhau không
            if (earliestDate == latestDate)
            {
                Mid_Usage_Date = earliestDate;
            }
            else
            {
                // Tính toán ngày giữa
                TimeSpan timeSpan = latestDate - earliestDate;
                DateTime midDate = earliestDate.AddDays(timeSpan.TotalDays / 2);
                Mid_Usage_Date = midDate;
            }

            Earliest_Usage_Date = earliestDate;
            Latest_Usage_Date = latestDate;
        }
        //Hàm để dựng chart most function used
        private void GetUsageChartData()
        {
            // Khởi tạo biến lưu trữ dữ liệu
            Dictionary<int, int> earliestPageIdCount = new Dictionary<int, int>();
            Dictionary<int, int> midPageIdCount = new Dictionary<int, int>();
            Dictionary<int, int> latestPageIdCount = new Dictionary<int, int>();

            if (AccessLogs != null && AccessLogs.Any())
            {
                foreach (var accessLog in AccessLogs)
                {
                    int pageId = accessLog.PageId;
                    DateTime accessDate = accessLog.Timestamp.Date;

                    // Tính toán số lần truy cập cho mỗi PageId tại các ngày khác nhau
                    if (accessDate == Earliest_Usage_Date)
                    {
                        if (earliestPageIdCount.ContainsKey(pageId))
                            earliestPageIdCount[pageId]++;
                        else
                            earliestPageIdCount[pageId] = 1;
                    }
                    else if (accessDate == Mid_Usage_Date)
                    {
                        if (midPageIdCount.ContainsKey(pageId))
                            midPageIdCount[pageId]++;
                        else
                            midPageIdCount[pageId] = 1;
                    }
                    else if (accessDate == Latest_Usage_Date)
                    {
                        if (latestPageIdCount.ContainsKey(pageId))
                            latestPageIdCount[pageId]++;
                        else
                            latestPageIdCount[pageId] = 1;
                    }
                }

                // Tính toán Most_Used_Id, Second_Used_Id, và Third_Used_Id cho mỗi ngày
                CalculateUsedIds(earliestPageIdCount, out int earliestMostUsedId, out int earliestSecondUsedId, out int earliestThirdUsedId);
                EarliestMostUsedId = earliestMostUsedId;
                EarliestSecondUsedId = earliestSecondUsedId;
                EarliestThirdUsedId = earliestThirdUsedId;

                CalculateUsedIds(midPageIdCount, out int midMostUsedId, out int midSecondUsedId, out int midThirdUsedId);
                MidMostUsedId = midMostUsedId;
                MidSecondUsedId = midSecondUsedId;
                MidThirdUsedId = midThirdUsedId;

                CalculateUsedIds(latestPageIdCount, out int latestMostUsedId, out int latestSecondUsedId, out int latestThirdUsedId);
                LatestMostUsedId = latestMostUsedId;
                LatestSecondUsedId = latestSecondUsedId;
                LatestThirdUsedId = latestThirdUsedId;
            }
        }

        private void CalculateUsedIds(Dictionary<int, int> pageIdCount, out int mostUsedId, out int secondUsedId, out int thirdUsedId)
        {
            mostUsedId = 0;
            secondUsedId = 0;
            thirdUsedId = 0;

            var sortedPageIdCount = pageIdCount.OrderByDescending(x => x.Value).ToList();

            if (sortedPageIdCount.Any())
            {
                mostUsedId = sortedPageIdCount.First().Key;
                if (sortedPageIdCount.Count >= 2)
                    secondUsedId = sortedPageIdCount[1].Key;
                if (sortedPageIdCount.Count >= 3)
                    thirdUsedId = sortedPageIdCount[2].Key;
            }
        }

        //Hàm handle
        private async Task HandleDataAsync()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            //Call API
            Top5NewUsers = await GetDataFromApiAsync<Users>("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");
            AccessLogs = await GetDataFromApiAsync<AccessLogs>("http://languagefree.cosplane.asia/AccessLogs");
            Comments = await GetDataFromApiAsync<Comments>("http://languagefree.cosplane.asia/Comments");
            Rates = await GetDataFromApiAsync<Rates>("http://languagefree.cosplane.asia/Rates");
            PageScreens = await GetDataFromApiAsync<PageScreens>("http://languagefree.cosplane.asia/Pages");

            //Hàm lấy tổng các giá trị
            TotalUserIds = GetTotalCount(Top5NewUsers);
            TotalAccessLogsIds = GetTotalCount(AccessLogs);
            TotalCommentsIds = GetTotalCount(Comments);
            TotalRatesIds = GetTotalCount(Rates);
            //Hàm tính trung bình số sao
            CalculateAverageRateIds();
            //Hàm phân tích giới tính người dùng
            CalculateUserGenderStatistics();
            //Hàm phân tích giới tính người dùng
            CalculateUserAgeStatistics();
            //Hàm phân tích xu hướng thời điểm người dùng
            // .......
            //Hàm Function được sử dụng nhiều nhất
            CalculateMostFrequentPage();
            //Hàm phần trăm của function sử dụng nhiều nhất
            CalculatePageAccessPercentages();
            //Hàm biểu thị thời gian của function sử dụng nhiều nhất
            GetUsageTimePeriod();
            //Hàm cung cấp dữ liệu cho chart most function used
            GetUsageChartData();
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
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var accessToken = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                await HandleDataAsync();
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");
                var responseUserReal = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/getAllWithRole?roleid=1&status=1");
                var response1 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Comments");
                var response2 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");
                var response3 = await _httpClient.GetAsync("http://languagefree.cosplane.asia/AccessLogs");
                string token = HttpContext.Session.GetString("AccessToken") ?? "";
                (UserName, UserId) = DecodeJwtToken(token);
                UpdateUserDTO.UserTempDTO = new UserTempDTO();
                UpdateUserDTO.UploadModel = new ImageUploadModel();
                try
                {
                    HttpResponseMessage responseU = await _httpClient.GetAsync("http://languagefree.cosplane.asia/Users/GetByAccountByID/" + UserId);

                    if (responseU.IsSuccessStatusCode)
                    {
                        temp = await responseU.Content.ReadFromJsonAsync<UsersDTO>();
                        HttpContext.Session.SetString("imageName", temp.ImageUser);
                        HttpContext.Session.SetString("fullName", temp.FullName);
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

                if (response.IsSuccessStatusCode && response1.IsSuccessStatusCode && response2.IsSuccessStatusCode && response3.IsSuccessStatusCode && responseUserReal.IsSuccessStatusCode)
                {
                    LanguageLogs = await response2.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    //LanguageSource
                    int AfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    int SqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    int AmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    int ArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    int HyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    int AzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    int EuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    int BnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    int BgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    int CaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    int ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    int ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    int HrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    int CsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    int DaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    int NlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    int EnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    int EtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    int FiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    int FrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    int GlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    int KaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    int DeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    int ElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    int GuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    int IwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    int HiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    int HuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    int IsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    int IdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    int ItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    int JaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    int KnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    int KkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    int KmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    int KoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    int LoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    int LvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    int LtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    int MkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    int MsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    int MlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    int MrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    int MnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    int MyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    int NeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    int FaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    int PlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    int PtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    int PaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    int RoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    int RuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    int SrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    int StCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    int SiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    int SkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    int SlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    int EsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    int SwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    int SvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    int TaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    int TeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    int ThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    int TrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    int UkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    int UrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    int UzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    int ViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    int XhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    int ZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

                    //LanguageTarget
                    int AfCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    int SqCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    int AmCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    int ArCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    int HyCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    int AzCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    int EuCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    int BnCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    int BgCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    int CaCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    int ZhCnCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    int ZhTwCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    int HrCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    int CsCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    int DaCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    int NlCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    int EnCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    int EtCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    int FiCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    int FrCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    int GlCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    int KaCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    int DeCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    int ElCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    int GuCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    int IwCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    int HiCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    int HuCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    int IsCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    int IdCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    int ItCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    int JaCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    int KnCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    int KkCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    int KmCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    int KoCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    int LoCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    int LvCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    int LtCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    int MkCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    int MsCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    int MlCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    int MrCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    int MnCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    int MyCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    int NeCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    int FaCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    int PlCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    int PtCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    int PaCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    int RoCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    int RuCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    int SrCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    int StCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    int SiCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    int SkCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    int SlCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    int EsCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    int SwCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    int SvCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    int TaCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    int TeCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    int ThCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    int TrCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    int UkCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    int UrCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    int UzCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    int ViCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    int XhCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    int ZuCount2 = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                    //LanguageSource
                    var languageCounts = new List<(string Language, int Count)>
                    {
                        ("Afrikaans (South Africa)", AfCount),
                        ("Albanian (Albania)", SqCount),
                        ("Amharic (Ethiopia)", AmCount),
                        ("Arabic (Egypt)", ArCount),
                        ("Azerbaijani (Azerbaijan)", AzCount),
                        ("Armenian (Armenia)", HyCount),
                        ("Basque (Spain)", EuCount),
                        ("Bengali (India)", BnCount),
                        ("Bulgarian (Bulgaria)", BgCount),
                        ("Catalan (Spain)", CaCount),
                        ("Chinese Simplified (China)", ZhCnCount),
                        ("Chinese Traditional (Taiwan)", ZhTwCount),
                        ("Croatian (Croatia)", HrCount),
                        ("Czech (Czech Republic)", CsCount),
                        ("Danish (Denmark)", DaCount),
                        ("Dutch (Netherlands)", NlCount),
                        ("English (United Kingdom)", EnCount),
                        ("Estonian (Estonia)", EtCount),
                        ("Finnish (Finland)", FiCount),
                        ("French (France)", FrCount),
                        ("Galician (Spain)", GlCount),
                        ("Georgian (Georgia)", KaCount),
                        ("German (Germany)", DeCount),
                        ("Greek (Greece)", ElCount),
                        ("Gujarati (India)", GuCount),
                        ("Hebrew (Israel)", IwCount),
                        ("Hindi (India)", HiCount),
                        ("Hungarian (Hungary)", HuCount),
                        ("Icelandic (Iceland)", IsCount),
                        ("Indonesian (Indonesia)", IdCount),
                        ("Italian (Italy)", ItCount),
                        ("Japanese (Japan)", JaCount),
                        ("Kannada (India)", KnCount),
                        ("Kazakh (Kazakhstan)", KkCount),
                        ("Khmer (Cambodia)", KmCount),
                        ("Korean (South Korea)", KoCount),
                        ("Lao (Laos)", LoCount),
                        ("Latvian (Latvia)", LvCount),
                        ("Lithuanian (Lithuania)", LtCount),
                        ("Macedonian (Macedonia (FYROM))", MkCount),
                        ("Malay (Malaysia)", MsCount),
                        ("Malayalam (India)", MlCount),
                        ("Marathi (India)", MrCount),
                        ("Mongolian (Mongolia)", MnCount),
                        ("Burmese (Myanmar (Burma))", MyCount),
                        ("Nepali (Nepal)", NeCount),
                        ("Persian (Iran)", FaCount),
                        ("Polish (Poland)", PlCount),
                        ("Portuguese (Brazil)", PtCount),
                        ("Punjabi (Gurmukhi, India)", PaCount),
                        ("Romanian (Romania)", RoCount),
                        ("Russian (Russia)", RuCount),
                        ("Serbian (Serbia)", SrCount),
                        ("Southern Sotho (Latin, Lesotho)", StCount),
                        ("Sinhala (Sri Lanka)", SiCount),
                        ("Slovak (Slovakia)", SkCount),
                        ("Slovenian (Slovenia)", SlCount),
                        ("Spanish (Argentina)", EsCount),
                        ("Swahili", SwCount),
                        ("Swedish (Sweden)", SvCount),
                        ("Tamil (Sri Lanka)", TaCount),
                        ("Telugu (India)", TeCount),
                        ("Thai (Thailand)", ThCount),
                        ("Turkish (Turkey)", TrCount),
                        ("Ukrainian (Ukraine)", UkCount),
                        ("Urdu (Pakistan)", UrCount),
                        ("Uzbek (Uzbekistan)", UzCount),
                        ("Vietnamese (Vietnam)", ViCount),
                        ("Xhosa (South Africa)", XhCount),
                        ("Zulu (South Africa)", ZuCount)
                    };

                    //LanguageTarget
                    var languageCounts2 = new List<(string Language, int Count)>
                    {
                        ("Afrikaans (South Africa)", AfCount2),
                        ("Albanian (Albania)", SqCount2),
                        ("Amharic (Ethiopia)", AmCount2),
                        ("Arabic (Egypt)", ArCount2),
                        ("Azerbaijani (Azerbaijan)", AzCount2),
                        ("Armenian (Armenia)", HyCount2),
                        ("Basque (Spain)", EuCount2),
                        ("Bengali (India)", BnCount2),
                        ("Bulgarian (Bulgaria)", BgCount2),
                        ("Catalan (Spain)", CaCount2),
                        ("Chinese Simplified (China)", ZhCnCount2),
                        ("Chinese Traditional (Taiwan)", ZhTwCount2),
                        ("Croatian (Croatia)", HrCount2),
                        ("Czech (Czech Republic)", CsCount2),
                        ("Danish (Denmark)", DaCount2),
                        ("Dutch (Netherlands)", NlCount2),
                        ("English (United Kingdom)", EnCount2),
                        ("Estonian (Estonia)", EtCount2),
                        ("Finnish (Finland)", FiCount2),
                        ("French (France)", FrCount2),
                        ("Galician (Spain)", GlCount2),
                        ("Georgian (Georgia)", KaCount2),
                        ("German (Germany)", DeCount2),
                        ("Greek (Greece)", ElCount2),
                        ("Gujarati (India)", GuCount2),
                        ("Hebrew (Israel)", IwCount2),
                        ("Hindi (India)", HiCount2),
                        ("Hungarian (Hungary)", HuCount2),
                        ("Icelandic (Iceland)", IsCount2),
                        ("Indonesian (Indonesia)", IdCount2),
                        ("Italian (Italy)", ItCount2),
                        ("Japanese (Japan)", JaCount2),
                        ("Kannada (India)", KnCount2),
                        ("Kazakh (Kazakhstan)", KkCount2),
                        ("Khmer (Cambodia)", KmCount2),
                        ("Korean (South Korea)", KoCount2),
                        ("Lao (Laos)", LoCount2),
                        ("Latvian (Latvia)", LvCount2),
                        ("Lithuanian (Lithuania)", LtCount2),
                        ("Macedonian (Macedonia (FYROM))", MkCount2),
                        ("Malay (Malaysia)", MsCount2),
                        ("Malayalam (India)", MlCount2),
                        ("Marathi (India)", MrCount2),
                        ("Mongolian (Mongolia)", MnCount2),
                        ("Burmese (Myanmar (Burma))", MyCount2),
                        ("Nepali (Nepal)", NeCount2),
                        ("Persian (Iran)", FaCount2),
                        ("Polish (Poland)", PlCount2),
                        ("Portuguese (Brazil)", PtCount2),
                        ("Punjabi (Gurmukhi, India)", PaCount2),
                        ("Romanian (Romania)", RoCount2),
                        ("Russian (Russia)", RuCount2),
                        ("Serbian (Serbia)", SrCount2),
                        ("Southern Sotho (Latin, Lesotho)", StCount2),
                        ("Sinhala (Sri Lanka)", SiCount2),
                        ("Slovak (Slovakia)", SkCount2),
                        ("Slovenian (Slovenia)", SlCount2),
                        ("Spanish (Argentina)", EsCount2),
                        ("Swahili", SwCount2),
                        ("Swedish (Sweden)", SvCount2),
                        ("Tamil (Sri Lanka)", TaCount2),
                        ("Telugu (India)", TeCount2),
                        ("Thai (Thailand)", ThCount2),
                        ("Turkish (Turkey)", TrCount2),
                        ("Ukrainian (Ukraine)", UkCount2),
                        ("Urdu (Pakistan)", UrCount2),
                        ("Uzbek (Uzbekistan)", UzCount2),
                        ("Vietnamese (Vietnam)", ViCount2),
                        ("Xhosa (South Africa)", XhCount2),
                        ("Zulu (South Africa)", ZuCount2)
                    };

                    //LanguageSource
                    var sortedLanguageCounts = languageCounts.OrderByDescending(lc => lc.Count).ToList();
                    var top5Languages = sortedLanguageCounts.Take(5).ToList();
                    int otherCount = sortedLanguageCounts.Skip(5).Sum(lc => lc.Count);
                    var newLabels = top5Languages.Select(lc => lc.Language).Concat(new[] { "Other" }).ToArray();
                    var newData = top5Languages.Select(lc => lc.Count).Concat(new[] { otherCount }).ToArray();
                    var labels = System.Text.Json.JsonSerializer.Serialize(newLabels);
                    var datas = System.Text.Json.JsonSerializer.Serialize(newData);
                    ViewData["datas"] = datas;
                    ViewData["lb2"] = labels;
                    //LanguageTarget
                    var sortedLanguageCounts2 = languageCounts2.OrderByDescending(lc => lc.Count).ToList();
                    var top5Languages2 = sortedLanguageCounts2.Take(5).ToList();
                    int otherCount2 = sortedLanguageCounts2.Skip(5).Sum(ll => ll.Count);
                    var newLabels2 = top5Languages2.Select(ll => ll.Language).Concat(new[] { "Other" }).ToArray();
                    var newData2 = top5Languages2.Select(ll => ll.Count).Concat(new[] { otherCount2 }).ToArray();
                    var labels2 = System.Text.Json.JsonSerializer.Serialize(newLabels2);
                    var datas2 = System.Text.Json.JsonSerializer.Serialize(newData2);
                    ViewData["datas2"] = datas2;
                    ViewData["lb3"] = labels2;

                    Comments = await response1.Content.ReadFromJsonAsync<List<Comments>>();
                    Top5NewUsers = await response.Content.ReadFromJsonAsync<List<Users>>();
                    Users = Top5NewUsers;
                    UsersTop5Real = await responseUserReal.Content.ReadFromJsonAsync<List<Users>>();
                    AccessLogs = await response3.Content.ReadFromJsonAsync<List<AccessLogs>>();
                    UserActivityCount = new Dictionary<string, int>
            {
                { "0_2", 0 },
                { "2_4", 0 },
                { "4_6", 0 },
                { "6_8", 0 },
                { "8_10", 0 },
                { "10_12", 0 },
                { "12_14", 0 },
                { "14_16", 0 },
                { "16_18", 0 },
                { "18_20", 0 },
                { "20_22", 0 },
                { "22_24", 0 },

            };
                    foreach (var log in AccessLogs)
                    {
                        // Lấy giờ từ Timestamp và tăng số lượng UserID tương ứng
                        var hour = log.Timestamp.Hour;

                        if (hour >= 0 && hour < 2)
                        {
                            UserActivityCount["0_2"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 2 && hour < 4)
                        {
                            UserActivityCount["2_4"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 4 && hour < 6)
                        {
                            UserActivityCount["4_6"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 6 && hour < 8)
                        {
                            UserActivityCount["6_8"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 8 && hour < 10)
                        {
                            UserActivityCount["8_10"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 10 && hour < 12)
                        {
                            UserActivityCount["10_12"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 12 && hour < 14)
                        {
                            UserActivityCount["12_14"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 14 && hour < 16)
                        {
                            UserActivityCount["14_16"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 16 && hour < 18)
                        {
                            UserActivityCount["16_18"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 18 && hour < 20)
                        {
                            UserActivityCount["18_20"] += log.UserId > 0 ? 1 : 0;
                        }
                        else if (hour >= 20 && hour < 22)
                        {
                            UserActivityCount["20_22"] += log.UserId > 0 ? 1 : 0;
                        }
                        else
                        {
                            UserActivityCount["22_24"] += log.UserId > 0 ? 1 : 0;
                        }
                    }
                    var sortedUsers = Top5NewUsers.OrderByDescending(u => u.Timestamp).ToList();

                    var sortedFeedback = Comments.OrderByDescending(f => f.Timestamp).ToList();
                    UsersTop5Real = UsersTop5Real.OrderByDescending(u => u.Timestamp).Take(5).ToList();
                    Top5NewUsers = sortedUsers.Take(5).ToList();

                    Comments = sortedFeedback.Take(5).ToList();

                    RemainingUsers = sortedUsers.Skip(5).ToList();
                }
                else
                {
                    Top5NewUsers = new List<Users>();

                    Comments = new List<Comments>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Top5NewUsers = new List<Users>();
                Comments = new List<Comments>();

            }

            return Page();
        }


    }
}
