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
    public class RolesDAOTest
    {
        private Fixture _fixture;
        private RolesDAO _rolesDao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _rolesDao = new RolesDAO(_context);
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
        public async Task AddRoles_NewSuccess()
        {
            RolesDTO rolesTO = new RolesDTO
            {
                RoleName = "Admin",
            };

            await _rolesDao.AddRoles(rolesTO);

            var addedRoles = await _context.Role.FirstOrDefaultAsync();
            addedRoles.Should().NotBeNull();
            addedRoles.RoleName.Should().Be(rolesTO.RoleName);
            ClearAllData();
        }

        [TestMethod]
        public async Task AddRoles_Fail_1()
        {
            try
            {
                RolesDTO rolesTO = null;
                await _rolesDao.AddRoles(rolesTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding role: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddRoles_Fail_2()
        {

            try
            {
                RolesDTO rolesTO = new RolesDTO
                {
                    RoleName = "Admin",
                };

                var ex = new InvalidOperationException("RolesDTO exception");
                _contextMock.Setup(m => m.Role).Throws(ex);
                var rolesDao = new RolesDAO(_contextMock.Object);
                await rolesDao.AddRoles(rolesTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding role: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllRoles_Success()
        {
            Roles roles = new Roles
            {
                RoleName = "Admin",
            };
            Roles roles2 = new Roles
            {
                RoleName = "Admin",
            };
            _context.Add(roles);
            _context.Add(roles2);
            await _context.SaveChangesAsync();

            List<Roles> RolesList = new List<Roles>();
            RolesList.Add(roles);
            RolesList.Add(roles2);

            var result = await _rolesDao.GetAllRoles();
            result.Should().BeEquivalentTo(RolesList);
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllRoles_ReturnsEx()
        {

            try
            {
                var ex = new InvalidOperationException("RolesDao exception");
                _contextMock.Setup(m => m.Role).Throws(ex);
                var rolesDao = new RolesDAO(_contextMock.Object);
                await rolesDao.GetAllRoles();
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while getting all roles: ");
            }
            ClearAllData();
        }
    }
}
