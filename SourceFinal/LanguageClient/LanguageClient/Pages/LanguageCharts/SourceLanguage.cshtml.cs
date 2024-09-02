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
    public class SourceLanguageModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public List<LanguageLogs> LanguageLogs { get; private set; } = new List<LanguageLogs>();
        [BindProperty]
        public DateTime selectDateStart { get; set; } = DateTime.Now.AddDays(-1);
        [BindProperty]
        public DateTime selectDateEnd { get; set; } = DateTime.Now;

        public int TrueAfCount { get; set; }
        public int TrueSqCount { get; set; }
        public int TrueAmCount { get; set; }
        public int TrueArCount { get; set; }
        public int TrueHyCount { get; set; }
        public int TrueAzCount { get; set; }
        public int TrueEuCount { get; set; }
        public int TrueBnCount { get; set; }
        public int TrueBgCount { get; set; }
        public int TrueCaCount { get; set; }
        public int TrueZhCnCount { get; set; }
        public int TrueZhTwCount { get; set; }
        public int TrueHrCount { get; set; }
        public int TrueCsCount { get; set; }
        public int TrueDaCount { get; set; }
        public int TrueNlCount { get; set; }
        public int TrueEnCount { get; set; }
        public int TrueEtCount { get; set; }
        public int TrueFiCount { get; set; }
        public int TrueFrCount { get; set; }
        public int TrueGlCount { get; set; }
        public int TrueKaCount { get; set; }
        public int TrueDeCount { get; set; }
        public int TrueElCount { get; set; }
        public int TrueGuCount { get; set; }
        public int TrueIwCount { get; set; }
        public int TrueHiCount { get; set; }
        public int TrueHuCount { get; set; }
        public int TrueIsCount { get; set; }
        public int TrueIdCount { get; set; }
        public int TrueItCount { get; set; }
        public int TrueJaCount { get; set; }
        public int TrueKnCount { get; set; }
        public int TrueKkCount { get; set; }
        public int TrueKmCount { get; set; }
        public int TrueKoCount { get; set; }
        public int TrueLoCount { get; set; }
        public int TrueLvCount { get; set; }
        public int TrueLtCount { get; set; }
        public int TrueMkCount { get; set; }
        public int TrueMsCount { get; set; }
        public int TrueMlCount { get; set; }
        public int TrueMrCount { get; set; }
        public int TrueMnCount { get; set; }
        public int TrueMyCount { get; set; }
        public int TrueNeCount { get; set; }
        public int TrueFaCount { get; set; }
        public int TruePlCount { get; set; }
        public int TruePtCount { get; set; }
        public int TruePaCount { get; set; }
        public int TrueRoCount { get; set; }
        public int TrueRuCount { get; set; }
        public int TrueSrCount { get; set; }
        public int TrueStCount { get; set; }
        public int TrueSiCount { get; set; }
        public int TrueSkCount { get; set; }
        public int TrueSlCount { get; set; }
        public int TrueEsCount { get; set; }
        public int TrueSwCount { get; set; }
        public int TrueSvCount { get; set; }
        public int TrueTaCount { get; set; }
        public int TrueTeCount { get; set; }
        public int TrueThCount { get; set; }
        public int TrueTrCount { get; set; }
        public int TrueUkCount { get; set; }
        public int TrueUrCount { get; set; }
        public int TrueUzCount { get; set; }
        public int TrueViCount { get; set; }
        public int TrueXhCount { get; set; }
        public int TrueZuCount { get; set; }
        public SourceLanguageModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var token = HttpContext.Session.GetString("AccessToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");

                if (response.IsSuccessStatusCode)
                {

                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();
                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();

                TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

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
                var response = await _httpClient.GetAsync("http://languagefree.cosplane.asia/LanguageLogs");

                if (response.IsSuccessStatusCode)
                {

                    LanguageLogs = await response.Content.ReadFromJsonAsync<List<LanguageLogs>>();
                    LanguageLogs = LanguageLogs.Where(u => u.Timestamp.Date >= selectDateStart && u.Timestamp.Date <= selectDateEnd).ToList();

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();
                TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

            }
            return Page();
        }
        public async Task<IActionResult> OnPostWeekSource()
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


                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();

                TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


            }
            return Page();
        }
        public async Task<IActionResult> OnPostMonthSource()
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


                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));

                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();

                TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


            }
            return Page();
        }
        public async Task<IActionResult> OnPostQuarterSource()
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

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();

                TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


            }
            return Page();
        }
        public async Task<IActionResult> OnPostYearSource()
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


                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
                else
                {
                    LanguageLogs = new List<LanguageLogs>();

                    TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                    TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                    TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                    TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                    TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                    TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                    TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                    TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                    TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                    TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                    TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                    TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                    TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                    TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                    TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                    TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                    TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                    TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                    TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                    TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                    TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                    TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                    TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                    TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                    TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                    TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                    TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                    TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                    TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                    TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                    TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                    TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                    TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                    TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                    TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                    TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                    TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                    TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                    TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                    TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                    TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                    TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                    TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                    TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                    TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                    TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                    TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                    TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                    TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                    TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                    TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                    TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                    TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                    TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                    TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                    TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                    TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                    TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                    TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                    TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                    TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                    TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                    TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                    TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                    TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                    TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                    TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                    TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                    TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                    TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                LanguageLogs = new List<LanguageLogs>();

                TrueAfCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "af" || l.LanguageTarget == "af_ZA"));
                TrueSqCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sq" || l.LanguageTarget == "sq_AL"));
                TrueAmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "am" || l.LanguageTarget == "am_ET"));
                TrueArCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ar" || l.LanguageTarget == "ar_EG"));
                TrueHyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hy" || l.LanguageTarget == "hy_AM"));
                TrueAzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "az" || l.LanguageTarget == "az_AZ"));
                TrueEuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "eu" || l.LanguageTarget == "eu_ES"));
                TrueBnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bn" || l.LanguageTarget == "bn_IN"));
                TrueBgCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "bg" || l.LanguageTarget == "bg_BG"));
                TrueCaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ca" || l.LanguageTarget == "ca_ES"));
                TrueZhCnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-cn" || l.LanguageTarget == "cmn_CN"));
                TrueZhTwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zh-tw" || l.LanguageTarget == "cmn_TW"));
                TrueHrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hr" || l.LanguageTarget == "hr_HR"));
                TrueCsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "cs" || l.LanguageTarget == "cs_CZ"));
                TrueDaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "da" || l.LanguageTarget == "da_DK"));
                TrueNlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "nl" || l.LanguageTarget == "nl_NL"));
                TrueEnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "en" || l.LanguageTarget == "en_GB"));
                TrueEtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "et" || l.LanguageTarget == "et_EE"));
                TrueFiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fi" || l.LanguageTarget == "fi_FI"));
                TrueFrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fr" || l.LanguageTarget == "fr_FR"));
                TrueGlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gl" || l.LanguageTarget == "gl_ES"));
                TrueKaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ka" || l.LanguageTarget == "ka_GE"));
                TrueDeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "de" || l.LanguageTarget == "de_DE"));
                TrueElCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "el" || l.LanguageTarget == "el_GR"));
                TrueGuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "gu" || l.LanguageTarget == "gu_IN"));
                TrueIwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "iw" || l.LanguageTarget == "iw_IL"));
                TrueHiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hi" || l.LanguageTarget == "hi_IN"));
                TrueHuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "hu" || l.LanguageTarget == "hu_HU"));
                TrueIsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "is" || l.LanguageTarget == "is_IS"));
                TrueIdCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "id" || l.LanguageTarget == "su_ID"));
                TrueItCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "it" || l.LanguageTarget == "it_IT"));
                TrueJaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ja" || l.LanguageTarget == "ja_JP"));
                TrueKnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kn" || l.LanguageTarget == "kn_IN"));
                TrueKkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "kk" || l.LanguageTarget == "kk_KZ"));
                TrueKmCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "km" || l.LanguageTarget == "km_KH"));
                TrueKoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ko" || l.LanguageTarget == "ko_KR"));
                TrueLoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lo" || l.LanguageTarget == "lo_LA"));
                TrueLvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lv" || l.LanguageTarget == "lv_LV"));
                TrueLtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "lt" || l.LanguageTarget == "lt_LT"));
                TrueMkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mk" || l.LanguageTarget == "mk_MK"));
                TrueMsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ms" || l.LanguageTarget == "ms_MY"));
                TrueMlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ml" || l.LanguageTarget == "ml_IN"));
                TrueMrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mr" || l.LanguageTarget == "mr_IN"));
                TrueMnCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "mn" || l.LanguageTarget == "mn_MN"));
                TrueMyCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "my" || l.LanguageTarget == "my_MM"));
                TrueNeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ne" || l.LanguageTarget == "ne_NP"));
                TrueFaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "fa" || l.LanguageTarget == "fa_IR"));
                TruePlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pl" || l.LanguageTarget == "pl_PL"));
                TruePtCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pt" || l.LanguageTarget == "pt_BR"));
                TruePaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "pa" || l.LanguageTarget == "pa_IN"));
                TrueRoCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ro" || l.LanguageTarget == "ro_RO"));
                TrueRuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ru" || l.LanguageTarget == "ru_RU"));
                TrueSrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sr" || l.LanguageTarget == "sr_RS"));
                TrueStCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "st" || l.LanguageTarget == "st_LS"));
                TrueSiCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "si" || l.LanguageTarget == "si_LK"));
                TrueSkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sk" || l.LanguageTarget == "sk_SK"));
                TrueSlCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sl" || l.LanguageTarget == "sl_SI"));
                TrueEsCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "es" || l.LanguageTarget == "es_AR"));
                TrueSwCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sw" || l.LanguageTarget == "sw_SW"));
                TrueSvCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "sv" || l.LanguageTarget == "sv_SE"));
                TrueTaCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ta" || l.LanguageTarget == "ta_LK"));
                TrueTeCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "te" || l.LanguageTarget == "te_IN"));
                TrueThCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "th" || l.LanguageTarget == "th_TH"));
                TrueTrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "tr" || l.LanguageTarget == "tr_TR"));
                TrueUkCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uk" || l.LanguageTarget == "uk_UA"));
                TrueUrCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "ur" || l.LanguageTarget == "ur_PK"));
                TrueUzCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "uz" || l.LanguageTarget == "uz_UZ"));
                TrueViCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "vi" || l.LanguageTarget == "vi_VN"));
                TrueXhCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "xh" || l.LanguageTarget == "xh_ZA"));
                TrueZuCount = LanguageLogs.Count(l => l.FromOrTo == true && (l.LanguageTarget == "zu" || l.LanguageTarget == "zu_ZA"));


            }
            return Page();
        }

    }
}
