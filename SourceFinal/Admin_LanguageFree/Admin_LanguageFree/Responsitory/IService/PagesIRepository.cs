using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.IService
{
    public interface PagesIRepository
    {
        Task NewPages(PagesDTO pages);
        Task<List<Pages>> GetAllPages();
        Task<bool> UpdatePage(int id, PagesDTO page);

    }
}
