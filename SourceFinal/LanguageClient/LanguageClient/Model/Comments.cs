using System;

namespace LanguageClient.Model
{
    public class Comments
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int PageId { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        public string CommentText { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
