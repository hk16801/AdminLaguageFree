using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess;
using DataAccess.DAO;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class TranslationHistorysDAOTest
    {
        private Fixture _fixture;
        private TranslationHistorysDAO _translationhistorysDao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _translationhistorysDao = new TranslationHistorysDAO(_context);
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
        public string DecodeString(string encodedString)
        {
            byte[] decodedBytes = Convert.FromBase64String(encodedString);
            string decodedString = Encoding.UTF8.GetString(decodedBytes);
            return decodedString;
        }
        private void ClearData<T>() where T : class
        {
            var entities = _context.Set<T>();
            _context.RemoveRange(entities);
        }

        [TestMethod]
        public async Task AddTranslationHistorys_NewSuccess()
        {
            TranslationHistorysDTO translationhistorysDTO = new TranslationHistorysDTO
            {
                UserId = 1,
                PageId = 1,
                SourceLanguage = "en",
                TargetLanguage = "vi",
                SourceText = "Test1",
                TranslatedText = "Test2",
                Location = "Test Location"
            };

            await _translationhistorysDao.AddTranslationHistorys(translationhistorysDTO);

            var addedTranslationHistorys = await _context.TranslationHistory.FirstOrDefaultAsync();
            string SourceText = DecodeString(addedTranslationHistorys.SourceText);
            string TranslatedText = DecodeString(addedTranslationHistorys.TranslatedText);
            addedTranslationHistorys.Should().NotBeNull();
            addedTranslationHistorys.UserId.Should().Be(translationhistorysDTO.UserId);
            addedTranslationHistorys.PageId.Should().Be(translationhistorysDTO.PageId);
            addedTranslationHistorys.SourceLanguage.Should().Be(translationhistorysDTO.SourceLanguage);
            addedTranslationHistorys.TargetLanguage.Should().Be(translationhistorysDTO.TargetLanguage);
            translationhistorysDTO.SourceText.Should().Be(SourceText);
            translationhistorysDTO.TranslatedText.Should().Be(TranslatedText);
            addedTranslationHistorys.Location.Should().Be(translationhistorysDTO.Location);
            ClearAllData();
        }

        [TestMethod]
        public async Task AddTranslationHistorys_Fail_1()
        {
            try
            {
                TranslationHistorysDTO translationhistorysDTO = null;
                await _translationhistorysDao.AddTranslationHistorys(translationhistorysDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding translation history: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddTranslationHistorys_Fail_2()
        {

            try
            {
                TranslationHistorysDTO translationhistorysDTO = new TranslationHistorysDTO
                {
                    UserId = 1,
                    PageId = 1,
                    SourceLanguage = "en",
                    TargetLanguage = "vi",
                    SourceText = "Test1",
                    TranslatedText = "Test2",
                    Location = "Test Location"
                };

                var ex = new InvalidOperationException("TranslationHistorysDTO exception");
                _contextMock.Setup(m => m.TranslationHistory).Throws(ex);
                var translationhistorysDao = new TranslationHistorysDAO(_contextMock.Object);
                await translationhistorysDao.AddTranslationHistorys(translationhistorysDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding translation history: ");
            }
            ClearAllData();
        }
    }
}
