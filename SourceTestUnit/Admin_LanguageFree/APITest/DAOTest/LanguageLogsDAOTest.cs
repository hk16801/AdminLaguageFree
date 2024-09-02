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
    public class LanguageLogsDAOTest
    {
        private Fixture _fixture;
        private LanguageLogsDAO _languagelogsDao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _languagelogsDao = new LanguageLogsDAO(_context);
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
        public async Task AddLanguageLogs_NewSuccess()
        {
            LanguageLogsDTO langualogsDTO = new LanguageLogsDTO
            {
                UserId = 1,
                PageId = 1,
                Location = "Test Location",
                LanguageTarget = "af",
                FromOrTo = true,
            };

            await _languagelogsDao.AddLanguageLogs(langualogsDTO);

            var addedLanguageLogs = await _context.LanguageLog.FirstOrDefaultAsync();
            addedLanguageLogs.Should().NotBeNull();
            addedLanguageLogs.UserId.Should().Be(langualogsDTO.UserId);
            addedLanguageLogs.PageId.Should().Be(langualogsDTO.PageId);
            addedLanguageLogs.LanguageTarget.Should().Be(langualogsDTO.LanguageTarget);
            addedLanguageLogs.FromOrTo.Should().Be(langualogsDTO.FromOrTo);
            ClearAllData();
        }
        [TestMethod]
        public async Task AddLanguageLogs_Fail_1()
        {
            try
            {
                LanguageLogsDTO languagelogsDTO = null;
                await _languagelogsDao.AddLanguageLogs(languagelogsDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding language logs: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddLanguageLogs_Fail_2()
        {

            try
            {
                LanguageLogsDTO langualogsDTO = new LanguageLogsDTO
                {
                    UserId = 1,
                    PageId = 1,
                    Location = "Test Location",
                    LanguageTarget = "af",
                    FromOrTo = true,
                };

                var ex = new InvalidOperationException("LanguageLogsDTO exception");
                _contextMock.Setup(m => m.AccessLog).Throws(ex);
                var languagelogsDao = new LanguageLogsDAO(_contextMock.Object);
                await languagelogsDao.AddLanguageLogs(langualogsDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding language logs: ");
            }
            ClearAllData();
        }
        [TestMethod]
        public async Task GetAllLanguageLogs_Success()
        {
            LanguageLogs languagelogsDTO = new LanguageLogs
            {
                UserId = 1,
                PageId = 1,
                Location = "Test Location",
                LanguageTarget = "af",
                FromOrTo = true,
                Timestamp = DateTime.Now,
            };
            LanguageLogs languagelogsDTO2 = new LanguageLogs
            {
                UserId = 1,
                PageId = 1,
                Location = "Test Location",
                LanguageTarget = "af",
                FromOrTo = true,
                Timestamp = DateTime.Now,
            };
            _context.Add(languagelogsDTO);
            _context.Add(languagelogsDTO2);
            await _context.SaveChangesAsync();

            List<LanguageLogs> LanguageLogsList = new List<LanguageLogs>();
            LanguageLogsList.Add(languagelogsDTO);
            LanguageLogsList.Add(languagelogsDTO2);

            var result = await _languagelogsDao.GetAllLanguageLogs();
            result.Should().BeEquivalentTo(LanguageLogsList);
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllLanguageLogs_ReturnsEx()
        {

            try
            {
                var ex = new InvalidOperationException("LanguageLogsDAO exception");
                _contextMock.Setup(m => m.LanguageLog).Throws(ex);
                var languagelogsDao = new LanguageLogsDAO(_contextMock.Object);
                await languagelogsDao.GetAllLanguageLogs();

            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while getting all language logs: ");
            }
            ClearAllData();
        }
    }
}
