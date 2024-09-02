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
    public class TranslationHistorysControllerTest
    {
        private Mock<TranslationHistorysIRepository> _repositoryMock;
        private Fixture _fixture;
        private TranslationHistorysController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<TranslationHistorysIRepository>();
            _fixture = new Fixture();
            _controller = new TranslationHistorysController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllTranslationHistorys_Success()
        {
            int userId = 1;
            List<TranslationHistorys> translationHistorys = new List<TranslationHistorys>
                {

                    new TranslationHistorys
                    {
                           TranslationId = 1,
                           UserId = 123,
                           PageId = 456,
                           SourceLanguage = "English",
                           TargetLanguage = "French",
                           SourceText = "Hello, how are you?",
                           TranslatedText = "Bonjour, comment ça va?",
                           Location = "Homepage",
                           Status = "Completed",
                           TranslationDate = DateTime.Now
                    },
                    new TranslationHistorys
                    {
                           TranslationId = 2,
                           UserId = 456,
                           PageId = 789,
                           SourceLanguage = "Spanish",
                           TargetLanguage = "English",
                           SourceText = "Hola, ¿cómo estás?",
                           TranslatedText = "Hello, how are you?",
                           Location = "About Us",
                           Status = "In Progress",
                           TranslationDate = DateTime.Now
                    },
                };
            _repositoryMock.Setup(repo => repo.GetAllTranslationHistorys(userId)).Returns(Task.FromResult(translationHistorys));
            var resultTask = _controller.GetAllTranslationHistorys(userId);
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(translationHistorys);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllTranslationHistorys_Fail()
        {
            int userId = 1;
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllTranslationHistorys(userId)).Throws(ex);
            var resultTask = _controller.GetAllTranslationHistorys(userId);
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
        public async Task GetAllTranslationHistorys_BadRequest()
        {
            int userId = 1;
            List<TranslationHistorys> translationHistorys = null;
            _repositoryMock.Setup(repo => repo.GetAllTranslationHistorys(userId)).Returns(Task.FromResult(translationHistorys));
            var resultTask = _controller.GetAllTranslationHistorys(userId);
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Translation History Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateNewTranslationHistory_Success()
        {
            TranslationHistorysDTO translation = new TranslationHistorysDTO
            {
                UserId = 123,
                PageId = 456,
                SourceLanguage = "English",
                TargetLanguage = "French",
                SourceText = "Hello, how are you?",
                TranslatedText = "Bonjour, comment ça va?",
                Location = "Homepage",
            };
            _repositoryMock.Setup(repo => repo.NewTranslationHistorys(translation)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewTranslationHistory(translation);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Translation history created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateNewTranslationHistory_Fail()
        {
            TranslationHistorysDTO translation = new TranslationHistorysDTO
            {
                UserId = 123,
                PageId = 456,
                SourceLanguage = "English",
                TargetLanguage = "French",
                SourceText = "Hello, how are you?",
                TranslatedText = "Bonjour, comment ça va?",
                Location = "Homepage",
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewTranslationHistorys(translation)).Throws(ex);
            var resultTask = _controller.CreateNewTranslationHistory(translation);
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
        public async Task RemoveTranslationHistory_Success()
        {
            int TranslationId = 1;
            _repositoryMock.Setup(repo => repo.RemoveTranslationHistory(TranslationId)).Returns(Task.CompletedTask);

            var result = await _controller.RemoveTranslationHistory(TranslationId);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Translation history delete successfully", okResult.Value);
        }

        [TestMethod]
        public async Task RemoveTranslationHistory_Exception_ReturnsInternalServerError()
        {
            int TranslationId = 1; 
            _repositoryMock.Setup(repo => repo.RemoveTranslationHistory(TranslationId)).Throws(new Exception("Simulated exception"));

            var result = await _controller.RemoveTranslationHistory(TranslationId);

            var statusCodeResult = result as ObjectResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
            statusCodeResult.Value.Should().Be("Internal server error Simulated exception");
        }

    }
}
