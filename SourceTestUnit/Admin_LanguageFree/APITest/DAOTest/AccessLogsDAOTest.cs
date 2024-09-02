using Admin_LanguageFree.Controllers;
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
using System.Threading.Tasks;

namespace APITest.DAOTest
{
    [TestClass]
    public class AccessLogsDAOTest
    {
        private Fixture _fixture;
        private AccessLogsDAO _dao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _dao = new AccessLogsDAO(_context);
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
        public async Task GetAllAccessLogs_ReturnsListOfAccessLogs()
        {
            AccessLogs accessLogs = new AccessLogs
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1",
                Timestamp = DateTime.Now,
            };
            AccessLogs accessLogs2 = new AccessLogs
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1",
                Timestamp = DateTime.Now,
            };
            _context.Add(accessLogs);
            _context.Add(accessLogs2);
            await _context.SaveChangesAsync();

            List<AccessLogs> accessLogsList = new List<AccessLogs>();
            accessLogsList.Add(accessLogs);
            accessLogsList.Add(accessLogs2);

            var result = await _dao.GetAllAccessLogs();
            result.Should().BeEquivalentTo(accessLogsList);
            ClearAllData();
        }
        [TestMethod]
        public async Task GetAllAccessLogs_ReturnsEx()
        {
            var ex = new Exception("Custom Exception");
            _contextMock.Setup(m => m.AccessLog).Throws(ex);
            var dao = new AccessLogsDAO(_contextMock.Object);
            var result = dao.GetAllAccessLogs();
            result.Exception.Message.Should().Be("One or more errors occurred. (AccessLogsDTO exception.)");
        }

        [TestMethod]
        public async Task AddAccessLogs_NewSuccess()
        {
            AccessLogsDTO accessDTO = new AccessLogsDTO
            {
                PageId = 1,
                UserId = 1,
                Location = "Test Location",

            };

            await _dao.AddAccessLogs(accessDTO);

            var addedAccessLogs = await _context.AccessLog.FirstOrDefaultAsync();
            addedAccessLogs.Should().NotBeNull(); 
            addedAccessLogs.PageId.Should().Be(accessDTO.PageId); 
            addedAccessLogs.UserId.Should().Be(accessDTO.UserId);
            addedAccessLogs.Location.Should().Be(accessDTO.Location);
            ClearAllData();
        }

        [TestMethod]
        public async Task AddAccessLogs_Fail_1()
        {
            try
            {
                AccessLogsDTO accessDTO = null;
                await _dao.AddAccessLogs(accessDTO);
            }catch (Exception ex)
            {
                ex.Message.Should().Be("AccessLogsDTO exception.");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddAccessLogs_Fail_2()
        {
            try
            {

                AccessLogsDTO accessDTO = new AccessLogsDTO
                {
                    PageId = 1,
                    UserId = 1,
                    Location = null,

                };

                await _dao.AddAccessLogs(accessDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().Be("AccessLogsDTO exception.");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddAccessLogs_Fail_3()
        {
            try
            {
                AccessLogsDTO accessDTO = new AccessLogsDTO
                {
                    PageId = 1,
                    UserId = 1,
                    Location = "Test Location",
                };
                var ex = new Exception("Custom Exception");
                _contextMock.Setup(m => m.AccessLog).Throws(ex);
                var accessDao = new AccessLogsDAO(_contextMock.Object);
                await accessDao.AddAccessLogs(accessDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().Be("AccessLogsDTO exception.");
            }
            ClearAllData();
        }
    }
}

