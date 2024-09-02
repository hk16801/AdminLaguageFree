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
    public class PagesControllerTest
    {
        private Mock<PagesIRepository> _repositoryMock;
        private Fixture _fixture;
        private PagesController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<PagesIRepository>();
            _fixture = new Fixture();
            _controller = new PagesController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllPages_Success()
        {
            List<Pages> pages = new List<Pages>
            {
                new Pages
                {
                     PageId = 1,
                     PageName = "Page 1"
                },
                new Pages
                {
                     PageId = 2,
                     PageName = "Page 2"
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllPages()).Returns(Task.FromResult(pages));
            var resultTask = _controller.GetAllPages();
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(pages);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllPages_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllPages()).Throws(ex);
            var resultTask = _controller.GetAllPages();
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
        public async Task GetAllPages_BadRequest()
        {
            List<Pages> pages = null;
            _repositoryMock.Setup(repo => repo.GetAllPages()).Returns(Task.FromResult(pages));
            var resultTask = _controller.GetAllPages();
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Page Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreatePages_Success()
        {
            PagesDTO pages = new PagesDTO
            {
                PageName = "Page 1"
            };
            _repositoryMock.Setup(repo => repo.NewPages(pages)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewPage(pages);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Page created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreatePages_Fail()
        {
            PagesDTO pages = new PagesDTO
            {
                PageName = "Page 1"
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewPages(pages)).Throws(ex);
            var resultTask = _controller.CreateNewPage(pages);
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
