using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface TranslationHistorysIRepository
    {
        Task NewTranslationHistorys(TranslationHistorysDTO translations);
        Task<List<TranslationHistorys>> GetAllTranslationHistorys(int userId);
        Task RemoveTranslationHistory(int id);

    }
}
