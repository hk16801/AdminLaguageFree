using System;

namespace LanguageClient.Model
{
    public class Users
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ImageUser { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime Timestamp { get; set; }
        public string National { get; set; }
    }
}
