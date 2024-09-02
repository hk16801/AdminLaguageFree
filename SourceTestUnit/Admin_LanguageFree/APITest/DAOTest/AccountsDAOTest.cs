using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess;
using DataAccess.DAO;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.DAOTest
{
    [TestClass]
    public class AccountsDAOTest
    {
        private Fixture _fixture;
        private AccountsDAO _accDao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _accDao = new AccountsDAO(_context);
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
        public async Task AddAccounts_NewSuccess()
        {
            AccountsDTO accountDTO = new AccountsDTO
            {
                Username = "adminTest",
                Password = "123456",
            };

            await _accDao.AddAccounts(accountDTO);

            var addedAccount = await _context.Account.FirstOrDefaultAsync();
            addedAccount.Should().NotBeNull();
            addedAccount.Username.Should().Be(accountDTO.Username);
            addedAccount.Password.Should().Be(accountDTO.Password);
            ClearAllData();
        }

        [TestMethod]
        public async Task AddAccounts_Fail_1()
        {
            try
            {
                AccountsDTO accountDTO = null;
                await _accDao.AddAccounts(accountDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().Be("AccountsDTO Exception.");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddAccounts_Fail_2()
        {
            try {
                AccountsDTO accountDTO = new AccountsDTO
                {
                    Username = "adminTest",
                    Password = "123456",
                };
                var ex = new Exception("Custom Exception");
                _contextMock.Setup(m => m.Account).Throws(ex);
                var acdao = new AccountsDAO(_contextMock.Object);
                await acdao.AddAccounts(accountDTO);
            }
            catch (Exception ex) {
                ex.Message.Should().Be("AccountsDTO Exception.");
            }
            ClearAllData();
        }
    }
}
