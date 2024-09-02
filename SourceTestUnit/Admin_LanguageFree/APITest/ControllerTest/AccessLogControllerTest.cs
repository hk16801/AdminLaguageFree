using Admin_LanguageFree.Controllers;
using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.ControllerTest
{
    [TestClass]
    public class AccessLogControllerTest
    {
        private Mock<AccessLogsIRepository> _repositoryMock;
        private Fixture _fixture;
        private AccessLogsController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<AccessLogsIRepository>();
            _fixture = new Fixture();
            _controller = new AccessLogsController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllAccessLogs_Success()
        {
            List<AccessLogs> accessLogs = new List<AccessLogs>
            {
                new AccessLogs
                {
                    AccessId = 1,
                    UserId = 1001,
                    PageId = 2001,
                    Location = "Location 1",
                    Timestamp = DateTime.Now
                },
                new AccessLogs
                {
                    AccessId = 2,
                    UserId = 1002,
                    PageId = 2002,
                    Location = "Location 2",
                    Timestamp = DateTime.Now.AddDays(-1)
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllAccessLogs()).Returns(Task.FromResult(accessLogs));
            var resultTask = _controller.GetAllAccessLogs();
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(accessLogs);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllAccessLogs_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllAccessLogs()).Throws(ex);
            var resultTask = _controller.GetAllAccessLogs();
            var result = await resultTask;
            if (result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllAccessLogs_BadRequest()
        {
            List<AccessLogs> accessLogs = null;
            _repositoryMock.Setup(repo => repo.GetAllAccessLogs()).Returns(Task.FromResult(accessLogs));
            var resultTask = _controller.GetAllAccessLogs();
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("AccessLog Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateAccessLogs_Success()
        {
            AccessLogsDTO accessLogs = new AccessLogsDTO
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1"
            };
            _repositoryMock.Setup(repo => repo.NewAccessLogs(accessLogs)).Returns(Task.CompletedTask); 
            var result = await _controller.CreateNewAccessLogs(accessLogs);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("AccessLog created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateAccessLogs_Fail()
        {
            AccessLogsDTO accessLogs = new AccessLogsDTO
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1"
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewAccessLogs(accessLogs)).Throws(ex);
            var resultTask = _controller.CreateNewAccessLogs(accessLogs);
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
