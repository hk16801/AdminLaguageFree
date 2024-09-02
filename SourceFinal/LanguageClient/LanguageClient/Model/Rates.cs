using System;

namespace LanguageClient.Model
{
    public class Rates
    {
        public int RateId { get; set; }
        public int UserId { get; set; }
        public int RateNum { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
