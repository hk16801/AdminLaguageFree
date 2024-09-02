using Admin_LanguageFree.Controllers;
using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reponsitory;
using Reponsitory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.ControllerTest
{
    [TestClass]
    public class SettingsControllerTest
    {
        private Mock<SettingsIRepository> _repositoryMock;
        private Fixture _fixture;
        private SettingsController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<SettingsIRepository>();
            _fixture = new Fixture();
            _controller = new SettingsController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetSettings_Success()
        {
            int userId = 1;
            Settings settings = new Settings
            {
                SettingId = 1,
                UserId = 1,
                UiLanguagePreference = "English",
                TranslationLanguageFrom = "English",
                TranslationLanguageTo = "Spanish",
                ConversationLanguageFrom = "English",
                ConversationLanguageTo = "French",
                PictureLangTo = "Spanish"
            };
    _repositoryMock.Setup(repo => repo.GetSettings(userId)).Returns(Task.FromResult(settings));
            var resultTask = _controller.GetSettings(userId);
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(settings);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetSettings_Fail()
        {
            int userId = 1;
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetSettings(userId)).Throws(ex);
            var resultTask = _controller.GetSettings(userId);
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
        public async Task GetSettings_BadRequest()
        {
            int userId = 1;
            Settings settings = null;
            _repositoryMock.Setup(repo => repo.GetSettings(userId)).Returns(Task.FromResult(settings));
            var resultTask = _controller.GetSettings(userId);
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Settings Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateSettings_Success()
        {
            SettingsDTO settings = new SettingsDTO
            {
                UserId = 1,
                UiLanguagePreference = "English",
                TranslationLanguageFrom = "English",
                TranslationLanguageTo = "Spanish",
                ConversationLanguageFrom = "English",
                ConversationLanguageTo = "French",
                PictureLangTo = "Spanish"
            };
            _repositoryMock.Setup(repo => repo.NewSettings(settings)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewSetting(settings);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Setting created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateSettings_Fail()
        {
            SettingsDTO settings = new SettingsDTO
            {
                UserId = 1,
                UiLanguagePreference = "English",
                TranslationLanguageFrom = "English",
                TranslationLanguageTo = "Spanish",
                ConversationLanguageFrom = "English",
                ConversationLanguageTo = "French",
                PictureLangTo = "Spanish"
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewSettings(settings)).Throws(ex);
            var resultTask = _controller.CreateNewSetting(settings);
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
