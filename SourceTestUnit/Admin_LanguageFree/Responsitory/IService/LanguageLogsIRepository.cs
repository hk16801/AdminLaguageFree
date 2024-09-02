using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface LanguageLogsIRepository
    {
        Task NewLanguageLogs(LanguageLogsDTO languages);
        Task<List<LanguageLogs>> GetAllLanguageLogs();
        //Task<bool> UpdateLanguageLogs(int id, LanguageLogsDTO language);
    }
}
