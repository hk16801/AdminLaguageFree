using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageClient.DTO
{
    public class SettingsDTO
    {
        public int UserId { get; set; }

        public string UiLanguagePreference { get; set; }

        public string TranslationLanguageFrom { get; set; }

        public string TranslationLanguageTo { get; set; }

        public string ConversationLanguageFrom { get; set; }

        public string ConversationLanguageTo { get; set; }
        public string PictureLangTo { get; set; }
    }
}
