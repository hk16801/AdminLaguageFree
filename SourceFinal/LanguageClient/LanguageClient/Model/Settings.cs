namespace LanguageClient.Model
{
    public class Settings
    {
        public int SettingId { get; set; }

        public int UserId { get; set; }

        public string UiLanguagePreference { get; set; }

        public string TranslationLanguageFrom { get; set; }

        public string TranslationLanguageTo { get; set; }

        public string ConversationLanguageFrom { get; set; }

        public string ConversationLanguageTo { get; set; }
        public string PictureLangTo { get; set; }
    }
}
