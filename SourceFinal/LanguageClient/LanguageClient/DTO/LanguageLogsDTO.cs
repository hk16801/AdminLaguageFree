using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageClient.DTO
{
    public class LanguageLogsDTO
    {
        public int UserId { get; set; }
        public int PageId { get; set; }
        public string Location { get; set; }
        public string LanguageTarget { get; set; }
        public bool FromOrTo { get; set; }

    }
}
