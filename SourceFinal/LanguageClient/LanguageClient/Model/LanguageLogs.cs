using System;

namespace LanguageClient.Model
{
    public class LanguageLogs
    {
        public int LangLogId { get; set; }
        public int UserId { get; set; }
        public int PageId { get; set; }
        public string Location { get; set; }
        public string LanguageTarget { get; set; }
        public bool FromOrTo { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
