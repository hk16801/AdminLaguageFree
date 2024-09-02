using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class Pages
    {
        [Key]
        public int PageId { get; set; } 

        public string PageName { get; set; }
    }
}
