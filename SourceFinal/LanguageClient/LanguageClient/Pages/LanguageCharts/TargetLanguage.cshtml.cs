using LanguageClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace LanguageClient.Pages.LanguageCharts
{
    public class TargetLanguageModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<LanguageLogs> LanguageLogs { get; private set; } = new List<LanguageLogs>();
        [BindProperty]
        public DateTime selectDateStart { get; set; } = DateTime.Now.AddDays(-1);
        [BindProperty]
        public DateTime selectDateEnd { get; set; } = DateTime.Now;

        public int AfCount { get; set; }
        public int SqCount { get; set; }
        public int AmCount { get; set; }
        public int ArCount { get; set; }
        public int HyCount { get; set; }
        public int AzCount { get; set; }
        public int EuCount { get; set; }
        public int BnCount { get; set; }
        public int BgCount { get; set; }
        public int CaCount { get; set; }
        public int ZhCnCount { get; set; }
        public int ZhTwCount { get; set; }
        public int HrCount { get; set; }
        public int CsCount { get; set; }
        public int DaCount { get; set; }
        public int NlCount { get; set; }
        public int EnCount { get; set; }
        public int EtCount { get; set; }
        public int FiCount { get; set; }
        public int FrCount { get; set; }
        public int GlCount { get; set; }
        public int KaCount { get; set; }
        public int DeCount { get; set; }
        public int ElCount { get; set; }
        public int GuCount { get; set; }
        public int IwCount { get; set; }
        public int HiCount { get; set; }
        public int HuCount { get; set; }
        public int IsCount { get; set; }
        public int IdCount { get; set; }
        public int ItCount { get; set; }
        public int JaCount { get; set; }
        public int KnCount { get; set; }
        public int KkCount { get; set; }
        public int KmCount { get; set; }
        public int KoCount { get; set; }
        public int LoCount { get; set; }
        public int LvCount { get; set; }
        public int LtCount { get; set; }
        public int MkCount { get; set; }
        public int MsCount { get; set; }
        public int MlCount { get; set; }
        public int MrCount { get; set; }
        public int MnCount { get; set; }
        public int MyCount { get; set; }
        public int NeCount { get; set; }
        public int FaCount { get; set; }
        public int PlCount { get; set; }
        public int PtCount { get; set; }
        public int PaCount { get; set; }
        public int RoCount { get; set; }
        public int RuCount { get; set; }
        public int SrCount { get; set; }
        public int StCount { get; set; }
        public int SiCount { get; set; }
        public int SkCount { get; set; }
        public int SlCount { get; set; }
        public int EsCount { get; set; }
        public int SwCount { get; set; }
        public int SvCount { get; set; }
        public int TaCount { get; set; }
        public int TeCount { get; set; }
        public int ThCount { get; set; }
        public int TrCount { get; set; }
        public int UkCount { get; set; }
        public int UrCount { get; set; }
        public int UzCount { get; set; }
        public int ViCount { get; set; }
        public int XhCount { get; set; }
        public int ZuCount { get; set; }


        public TargetLanguageModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> OnGet()
        {     try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");

                if (response.IsSuccessStatusCode)
                {

                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();
                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();
                AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

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
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");

                if (response.IsSuccessStatusCode)
                {
                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    LanguageLogs = LanguageLogs.Where(u => u.Timestamp.Date >= selectDateStart && u.Timestamp.Date <= selectDateEnd).ToList();

                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));



                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();
                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();
                AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


            }
            return Page();
        }
        public async Task<IActionResult> OnPostWeekTarget()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;

                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");

                if (response.IsSuccessStatusCode)
                {

                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    LanguageLogs = LanguageLogs.Where(u => u.Timestamp.Date >= selectDateStart && u.Timestamp.Date <= selectDateEnd).ToList();

                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();
                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();
                AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));



            }
            return Page();
        }
        public async Task<IActionResult> OnPostMonthTarget()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");

                if (response.IsSuccessStatusCode)
                {

                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    LanguageLogs = LanguageLogs.Where(u => u.Timestamp.Date >= selectDateStart && u.Timestamp.Date <= selectDateEnd).ToList();

                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();
                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();
                AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


            }
            return Page();
        }
        public async Task<IActionResult> OnPostQuarterTarget()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");

                if (response.IsSuccessStatusCode)
                {

                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    LanguageLogs = LanguageLogs.Where(u => u.Timestamp.Date >= selectDateStart && u.Timestamp.Date <= selectDateEnd).ToList();

                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));



                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();
                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();
                AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

            }
            return Page();
        }
        public async Task<IActionResult> OnPostYearTarget()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ModelState["selectDateStart"].RawValue = selectDateStart;
                ModelState["selectDateEnd"].RawValue = selectDateEnd;
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");
                if (response.IsSuccessStatusCode)
                {

                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    LanguageLogs = LanguageLogs.Where(u => u.Timestamp.Date >= selectDateStart && u.Timestamp.Date <= selectDateEnd).ToList();

                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();
                    AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                    ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                    HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();
                AfCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                SqCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                AmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                ArCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                HyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                AzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                EuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                BnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                BgCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                CaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                ZhCnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cn" || l.LanguageTarget == "cmn_CN"));
                ZhTwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tw" || l.LanguageTarget == "cmn_TW"));
                HrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                CsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                DaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                NlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                EnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                EtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                FiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                FrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                GlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                KaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                DeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                ElCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                GuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                IwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                HiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                HuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                IsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                IdCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                ItCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                JaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                KnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                KkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                KmCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                KoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                LoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                LvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                LtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                MkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                MsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                MlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                MrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                MnCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                MyCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                NeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                FaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                PlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                PtCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                PaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                RoCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                RuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                SrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                StCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                SiCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                SkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                SlCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                EsCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                SwCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                SvCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TaCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TeCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                ThCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                UkCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                UrCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                UzCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                ViCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                XhCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                ZuCount = LanguageLogs.Count(l => l.FromOrTo == false && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


            }
            return Page();
        }

    }
}
