using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; } 
        public int UserId { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public bool isVerify { get; set; }
        public DateTime Timestamp { get; set; }

        public int Status { get; set; }
    }
}
