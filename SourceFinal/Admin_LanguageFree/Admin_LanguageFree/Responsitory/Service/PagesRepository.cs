using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess.DAO;
using Reponsitory.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Service
{
    public class PagesRepository : PagesIRepository
    {
        private readonly PagesDAO _pagesDAO;

        public PagesRepository(PagesDAO pagesDAO)
        {
            _pagesDAO = pagesDAO;
        }
        public Task NewPages(PagesDTO pages)
        {
            return _pagesDAO.AddPages(pages);
        }
        public Task<List<Pages>> GetAllPages()
        {
            return _pagesDAO.GetAllPages();
        }

        public Task<bool> UpdatePage(int id, PagesDTO page)
        {
            return _pagesDAO.UpdatePage(id, page);
        }
    }
}
