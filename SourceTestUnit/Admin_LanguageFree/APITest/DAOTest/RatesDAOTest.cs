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
    public class RatesDAOTest
    {
        private Fixture _fixture;
        private RatesDAO _ratesDao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _ratesDao = new RatesDAO(_context);
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
        public async Task AddRates_NewSuccess()
        {
            RatesDTO ratesDTO = new RatesDTO
            {
                UserId = 1,
                RateNum = 5,
                Location = "Test Location"
            };

            await _ratesDao.AddRates(ratesDTO);

            var addedRates = await _context.Rate.FirstOrDefaultAsync();
            addedRates.Should().NotBeNull();
            addedRates.UserId.Should().Be(ratesDTO.UserId);
            addedRates.RateNum.Should().Be(ratesDTO.RateNum);
            addedRates.Location.Should().Be(ratesDTO.Location);
            ClearAllData();
        }
        [TestMethod]
        public async Task AddRates_Fail_1()
        {
            try
            {
                RatesDTO ratesDTO = null;
                await _ratesDao.AddRates(ratesDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding rates: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddRates_Fail_2()
        {

            try
            {
                RatesDTO ratesDTO = new RatesDTO
                {
                    UserId = 1,
                    RateNum = 5,
                    Location = "Test Location"
                };

                var ex = new InvalidOperationException("RatesDTO exception");
                _contextMock.Setup(m => m.Rate).Throws(ex);
                var ratesDao = new RatesDAO(_contextMock.Object);
                await ratesDao.AddRates(ratesDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding rates: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllRates_Success()
        {
            Rates rates = new Rates
            {
                UserId = 1,
                RateNum = 5,
                Location = "Test Location",
                Timestamp = DateTime.Now,
            };
            Rates rates2 = new Rates
            {
                UserId = 1,
                RateNum = 5,
                Location = "Test Location",
                Timestamp = DateTime.Now,
            };
            _context.Add(rates);
            _context.Add(rates2);
            await _context.SaveChangesAsync();

            List<Rates> RatesList = new List<Rates>();
            RatesList.Add(rates);
            RatesList.Add(rates2);

            var result = await _ratesDao.GetAllRates();
            result.Should().BeEquivalentTo(RatesList);
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllRates_ReturnsEx()
        {

            try
            {
                var ex = new InvalidOperationException("RatesDao exception");
                _contextMock.Setup(m => m.Rate).Throws(ex);
                var ratesDao = new RatesDAO(_contextMock.Object);
                await ratesDao.GetAllRates();
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while getting all rates: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task CanUserRate_True()
        {
            int userId = 1;

            bool canRate = await _ratesDao.CanUserRate(userId);
            canRate.Should().BeTrue();
            ClearAllData();
        }

        [TestMethod]
        public async Task CanUserRate_TrueThan10()
        {
            int userId = 1;
            DateTime lastRatingDate = DateTime.Now.AddDays(-11);

            Rates rates = new Rates
            {
                UserId = userId,
                RateNum = 5,
                Location = "Test Location",
                Timestamp = lastRatingDate,
            };

            _context.Add(rates);
            await _context.SaveChangesAsync();

            bool canRate = await _ratesDao.CanUserRate(userId);
            canRate.Should().BeTrue();
            ClearAllData();
        }

        [TestMethod]
        public async Task CanUserRate_TrueSmall10Fail()
        {
            int userId = 1;
            DateTime lastRatingDate = DateTime.Now.AddDays(-9);

            Rates rates = new Rates
            {
                UserId = userId,
                RateNum = 5,
                Location = "Test Location",
                Timestamp = lastRatingDate,
            };

            _context.Add(rates);
            await _context.SaveChangesAsync();

            bool canRate = await _ratesDao.CanUserRate(userId);
            canRate.Should().BeFalse();
            ClearAllData();
        }

        [TestMethod]
        public async Task CanUserRate_Fail()
        {
            // Arrange
            int userId = 1;
            DateTime lastRatingDate = DateTime.Now.AddDays(-11);

            Rates rates = new Rates
            {
                UserId = userId,
                RateNum = 5,
                Location = "Test Location",
                Timestamp = lastRatingDate,
            };

            _context.Add(rates);
            await _context.SaveChangesAsync();

            var expectedException = new InvalidOperationException("RatesDTO exception");
            _contextMock.Setup(m => m.Rate).Throws(expectedException);
            var ratesDao = new RatesDAO(_contextMock.Object);

            // Act
            bool canRate = false;
            string errorMessage = null;

            try
            {
                canRate = await ratesDao.CanUserRate(userId);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            // Assert
            canRate.Should().BeFalse();
            errorMessage.Should().StartWith("Error occurred while checking if user can rate:");

            ClearAllData();
        }

    }

}

