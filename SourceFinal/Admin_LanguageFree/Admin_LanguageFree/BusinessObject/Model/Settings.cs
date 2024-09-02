using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Settings
    {
        [Key]
        public int SettingId { get; set; } 

        public int UserId { get; set; } 

        public string UiLanguagePreference { get; set; }

        public string TranslationLanguageFrom { get; set; }

        public string TranslationLanguageTo { get; set; }

        public string ConversationLanguageFrom { get; set; }

        public string ConversationLanguageTo { get; set; }
        public string PictureLangTo { get;set; }
    }
}
