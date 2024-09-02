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
    public class LanguageLogsControllerTest
    {
        private Mock<LanguageLogsIRepository> _repositoryMock;
        private Fixture _fixture;
        private LanguageLogsController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<LanguageLogsIRepository>();
            _fixture = new Fixture();
            _controller = new LanguageLogsController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllLanguageLogs_Success()
        {
            List<LanguageLogs> languages = new List<LanguageLogs>
            {
                new LanguageLogs
                {
                     LangLogId = 1,
                     UserId = 1001,
                     PageId = 2001,
                     Location = "Location 1",
                     LanguageTarget = "Spanish",
                     FromOrTo = true,
                     Timestamp = DateTime.Now
                },
                new LanguageLogs
                {
                     LangLogId = 2,
                     UserId = 1002,
                     PageId = 2002,
                     Location = "Location 2",
                     LanguageTarget = "French",
                     FromOrTo = false,
                     Timestamp = DateTime.Now.AddDays(-1)
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllLanguageLogs()).Returns(Task.FromResult(languages));
            var resultTask = _controller.GetAllLanguageLogs();
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(languages);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllLanguageLogs_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllLanguageLogs()).Throws(ex);
            var resultTask = _controller.GetAllLanguageLogs();
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
        public async Task GetAllLanguageLogs_BadRequest()
        {
            List<LanguageLogs> languages = null;
            _repositoryMock.Setup(repo => repo.GetAllLanguageLogs()).Returns(Task.FromResult(languages));
            var resultTask = _controller.GetAllLanguageLogs();
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("LanguageLog Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateLanguageLogs_Success()
        {
            LanguageLogsDTO languages = new LanguageLogsDTO
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1",
                LanguageTarget = "Spanish",
                FromOrTo = true,
            };
            _repositoryMock.Setup(repo => repo.NewLanguageLogs(languages)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewLanguageLogs(languages);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("LanguageLog created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateLanguageLogs_Fail()
        {
            LanguageLogsDTO languages = new LanguageLogsDTO
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1",
                LanguageTarget = "Spanish",
                FromOrTo = true,
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewLanguageLogs(languages)).Throws(ex);
            var resultTask = _controller.CreateNewLanguageLogs(languages);
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
