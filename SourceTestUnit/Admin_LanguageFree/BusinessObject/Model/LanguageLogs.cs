using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class LanguageLogs
    {
        [Key]
        public int LangLogId { get; set; } 
        public int UserId { get; set; } 
        public int PageId { get; set; }
        public string Location { get; set; }
        public string LanguageTarget { get; set; }
        public bool FromOrTo { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
