using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class TranslationHistorys
    {
        [Key]
        public int TranslationId { get; set; } 

        public int UserId { get; set; } 

        public int PageId { get; set; }

        public string SourceLanguage { get; set; }

        public string TargetLanguage { get; set; }

        public string SourceText { get; set; }

        public string TranslatedText { get; set; }
        public string Location {  get; set; }
        public string Status { get; set; }

        public DateTime TranslationDate { get; set; }
    }
}
