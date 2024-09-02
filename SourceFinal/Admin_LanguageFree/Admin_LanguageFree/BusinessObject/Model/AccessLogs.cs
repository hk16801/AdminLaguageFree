using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class AccessLogs
    {
        [Key]
        public int AccessId { get; set; } 

        public int UserId { get; set; } 

        public int PageId { get; set; } 
        public string Location {  get; set; }

        public DateTime Timestamp { get; set; }
    }
}
