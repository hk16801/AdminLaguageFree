using System;

namespace LanguageClient.Model
{
    public class Accounts
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Status { get; set; }
    }
}
