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
    public class TranslationHistorysRepository : TranslationHistorysIRepository
    {
        private readonly TranslationHistorysDAO _translationHistorysDAO;

        public TranslationHistorysRepository(TranslationHistorysDAO translationHistorysDAO)
        {
            _translationHistorysDAO = translationHistorysDAO;
        }
        public Task NewTranslationHistorys(TranslationHistorysDTO translation)
        {
            return _translationHistorysDAO.AddTranslationHistorys(translation);
        }
        public Task<List<TranslationHistorys>> GetAllTranslationHistorys(int userId)
        {
            return _translationHistorysDAO.GetAllTranslationHistorys(userId);
        }
        public Task RemoveTranslationHistory(int id)
        {
            return _translationHistorysDAO.RemoveTranslationHistory(id);
        }
    }
}
