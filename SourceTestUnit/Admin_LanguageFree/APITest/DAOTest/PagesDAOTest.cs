using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess;
using DataAccess.DAO;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.DAOTest
{
    [TestClass]
    public class PagesDAOTest
    {
        private Fixture _fixture;
        private PagesDAO _pagesDao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _pagesDao = new PagesDAO(_context);
        }
        public void ClearAllData()
        {
            ClearData<Users>();
            ClearData<TranslationHistorys>();
            ClearData<Settings>();
            ClearData<Pages>();
            ClearData<LanguageLogs>();
            ClearData<Comments>();
            ClearData<Rates>();
            ClearData<Roles>();
            ClearData<Accounts>();
            ClearData<AccessLogs>();

            _context.SaveChanges();
        }

        private void ClearData<T>() where T : class
        {
            var entities = _context.Set<T>();
            _context.RemoveRange(entities);
        }

        [TestMethod]
        public async Task AddPages_NewSuccess()
        {
            PagesDTO pagesDTO = new PagesDTO
            {
                PageName = "Home",
            };

            await _pagesDao.AddPages(pagesDTO);

            var addedPages = await _context.Page.FirstOrDefaultAsync();
            addedPages.Should().NotBeNull();
            addedPages.PageName.Should().Be(pagesDTO.PageName);
            ClearAllData();
        }
        [TestMethod]
        public async Task AddPages_Fail_1()
        {
            try
            {
                PagesDTO pagesDTO = null;
                await _pagesDao.AddPages(pagesDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding page: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddPages_Fail_2()
        {

            try
            {
                PagesDTO pagesDTO = new PagesDTO
                {
                    PageName = "Home",
                };

                var ex = new InvalidOperationException("PagesDTO exception");
                _contextMock.Setup(m => m.Page).Throws(ex);
                var pagesDao = new PagesDAO(_contextMock.Object);
                await pagesDao.AddPages(pagesDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding page: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllPages_Success()
        {
            Pages pages = new Pages
            {
                PageName = "Home"
            };
            Pages pages2 = new Pages
            {
                PageName = "Home"
            };
            _context.Add(pages);
            _context.Add(pages2);
            await _context.SaveChangesAsync();

            List<Pages> PagesList = new List<Pages>();
            PagesList.Add(pages);
            PagesList.Add(pages2);

            var result = await _pagesDao.GetAllPages();
            result.Should().BeEquivalentTo(PagesList);
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllPages_ReturnsEx()
        {

            try
            {
                var ex = new InvalidOperationException("PagesDao exception");
                _contextMock.Setup(m => m.Page).Throws(ex);
                var pagesDao = new PagesDAO(_contextMock.Object);
                await pagesDao.GetAllPages();

            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while getting all pages: ");
            }
            ClearAllData();
        }
    }
}
