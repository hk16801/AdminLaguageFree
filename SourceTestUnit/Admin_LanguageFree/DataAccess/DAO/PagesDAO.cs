using BusinessObject.DTO;
using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class PagesDAO
    {
        private readonly DBContext _dBContext;
        public Pages pg { get; set; } = new Pages();

        public PagesDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddPages(PagesDTO pages)
        {
            try
            {
                if (pages == null)
                {
                    throw new ArgumentNullException(nameof(pages), "PagesDTO cannot be null.");
                }

                pg.PageName = pages.PageName;

                _dBContext.Page.Add(pg);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding page: {ex.Message}", ex);
            }
        }

        public async Task<List<Pages>> GetAllPages()
        {
            try
            {
                var pages = await _dBContext.Page.ToListAsync();
                return pages;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all pages: {ex.Message}", ex);
            }
        }

        //public async Task<bool> UpdatePage(int id, PagesDTO pages)
        //{
        //    try
        //    {
        //        var existingPage = await _dBContext.Page.FindAsync(id);

        //        if (existingPage == null)
        //            return false;

        //        existingPage.PageName = pages.PageName;
        //        await _dBContext.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error occurred while updating page: {ex.Message}", ex);
        //    }
        //}
    }
}
