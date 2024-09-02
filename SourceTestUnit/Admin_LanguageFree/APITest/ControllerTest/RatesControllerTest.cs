using Admin_LanguageFree.Controllers;
using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reponsitory;
using Reponsitory.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.ControllerTest
{
    [TestClass]
    public class RatesControllerTest
    {
        private Mock<RatesIRepository> _repositoryMock;
        private Fixture _fixture;
        private RatesController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<RatesIRepository>();
            _fixture = new Fixture();
            _controller = new RatesController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllRates_Success()
        {
            List<Rates> rates = new List<Rates>
            {
                new Rates
                {
                    RateId = 1,
                    UserId = 1001,
                    RateNum = 5,
                    Location = "Location 1",
                    Timestamp = DateTime.Now
                },
                new Rates
                {
                    RateId = 2,
                    UserId = 1002,
                    RateNum = 4,
                    Location = "Location 2",
                    Timestamp = DateTime.Now.AddDays(-1)
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllRates()).Returns(Task.FromResult(rates));
            var resultTask = _controller.GetAllRates();
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(rates);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllRates_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllRates()).Throws(ex);
            var resultTask = _controller.GetAllRates();
            var result = await resultTask;
            if (result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
                objectResult.Value.Should().Be("Internal server error");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllRates_BadRequest()
        {
            List<Rates> rates = null;
            _repositoryMock.Setup(repo => repo.GetAllRates()).Returns(Task.FromResult(rates));
            var resultTask = _controller.GetAllRates();
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Rate Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateRates_Success()
        {
            RatesDTO rates = new RatesDTO
            {
                UserId = 1001,
                RateNum = 5,
                Location = "Location 1",
            };
            _repositoryMock.Setup(repo => repo.NewRates(rates)).Returns(Task.CompletedTask);
            var result = await _controller.CreateRate(rates);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Rate created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateRates_Fail()
        {
            RatesDTO rates = new RatesDTO
            {
                UserId = 1001,
                RateNum = 5,
                Location = "Location 1",
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewRates(rates)).Throws(ex);
            var resultTask = _controller.CreateRate(rates);
            var result = await resultTask;
            if (result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
                objectResult.Value.Should().Be("Internal server error");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetRatesById_Success()
        {
            int userId = 1;
            CheckRate checkRate = new CheckRate
            {
                IsChecked = true,
            };
            List<Rates> rates = new List<Rates>
            {
                new Rates
                {
                    RateId = 1,
                    UserId = 1,
                    RateNum = 5,
                    Location = "Location 1",
                    Timestamp = DateTime.Now
                },
                new Rates
                {
                    RateId = 2,
                    UserId = 1,
                    RateNum = 4,
                    Location = "Location 2",
                    Timestamp = DateTime.Now.AddDays(-1)
                },
            };
            _repositoryMock.Setup(repo => repo.CanRate(userId)).Returns(Task.FromResult(true));
            var resultTask = _controller.CanUserRate(userId);
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(checkRate);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetRatesById_False()
        {
            int userId = 1;
            CheckRate checkRate = new CheckRate
            {
                IsChecked = false,
            };
            List<Rates> rates = new List<Rates>
            {
                new Rates
                {
                    RateId = 1,
                    UserId = 1,
                    RateNum = 5,
                    Location = "Location 1",
                    Timestamp = DateTime.Now
                },
                new Rates
                {
                    RateId = 2,
                    UserId = 1,
                    RateNum = 4,
                    Location = "Location 2",
                    Timestamp = DateTime.Now.AddDays(-1)
                },
            };
            _repositoryMock.Setup(repo => repo.CanRate(userId)).Returns(Task.FromResult(false));
            var resultTask = _controller.CanUserRate(userId);
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(checkRate);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetRatesById_Fail()
        {
            int userId = 1;

            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.CanRate(userId)).Throws(ex);
            var resultTask = _controller.CanUserRate(userId);
            var result = await resultTask;
            if (result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
                objectResult.Value.Should().Be("Internal server error");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
    }
}
