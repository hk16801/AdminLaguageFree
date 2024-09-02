using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class TranslationHistorysDTO
    {
        public int UserId { get; set; }

        public int PageId { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public string SourceText { get; set; }

        public string TranslatedText { get; set; }
        public string Location { get; set; }


    }
}
