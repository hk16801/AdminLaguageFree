using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Service
{
    public class LanguageLogsRepository : LanguageLogsIRepository
    {
        private readonly LanguageLogsDAO _languagelogsDAO;

        public LanguageLogsRepository(LanguageLogsDAO languageLogsDAO)
        {
            _languagelogsDAO = languageLogsDAO;
        }
        public Task NewLanguageLogs(LanguageLogsDTO language)
        {
            return _languagelogsDAO.AddLanguageLogs(language);
        }
        public Task<List<LanguageLogs>> GetAllLanguageLogs()
        {
            return _languagelogsDAO.GetAllLanguageLogs();
        }

        //public Task<bool> UpdateLanguageLogs(int id, LanguageLogsDTO language)
        //{
        //    return _languagelogsDAO.UpdateLanguageLogs(id, language);
        //}
    }
}
