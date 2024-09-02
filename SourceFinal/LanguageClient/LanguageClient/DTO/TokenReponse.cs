using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageClient.Model;

namespace LanguageClient.DTO
{
    public class TokenReponse
    {
        public Accounts Account { get; set; }
        public string AccessToken { get; set; }
    }
}