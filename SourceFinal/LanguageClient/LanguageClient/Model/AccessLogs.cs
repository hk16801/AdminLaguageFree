using System;

namespace LanguageClient.DTO
{
    public class AccessLogs
    {
        public int AccessId { get; set; }
        public int UserId { get; set; }

        public int PageId { get; set; }
        public string Location { get; set; }

        public DateTime Timestamp { get; set; }

    }
}
