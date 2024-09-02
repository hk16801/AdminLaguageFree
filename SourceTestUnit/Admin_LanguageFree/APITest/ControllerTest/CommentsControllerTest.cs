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
    public class CommentsControllerTest
    {
        private Mock<CommentsIRepository> _repositoryMock;
        private Fixture _fixture;
        private CommentsController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<CommentsIRepository>();
            _fixture = new Fixture();
            _controller = new CommentsController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllComments_Success()
        {
            List<Comments> comments = new List<Comments>
            {
                new Comments
                {
                    CommentId = 1,
                    UserId = 1001,
                    PageId = 2001,
                    Location = "Location 1",
                    Status = "Active",
                    CommentText = "This is the first comment",
                    Timestamp = DateTime.Now
                },
                new Comments
                {
                     CommentId = 2,
                     UserId = 1002,
                     PageId = 2001,
                     Location = "Location 2",
                     Status = "Inactive",
                     CommentText = "This is the second comment",
                     Timestamp = DateTime.Now.AddDays(-1)
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllComments()).Returns(Task.FromResult(comments));
            var resultTask = _controller.GetAllComments();
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(comments);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllComments_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllComments()).Throws(ex);
            var resultTask = _controller.GetAllComments();
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
        public async Task GetAllComments_BadRequest()
        {
            List<Comments> comments = null;
            _repositoryMock.Setup(repo => repo.GetAllComments()).Returns(Task.FromResult(comments));
            var resultTask = _controller.GetAllComments();
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Comment Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateComments_Success()
        {
            CommentsDTO comments = new CommentsDTO
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1",
                CommentText = "This is the first comment"
            };
            _repositoryMock.Setup(repo => repo.NewComments(comments)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewComments(comments);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Comment created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateComments_Fail()
        {
            CommentsDTO comments = new CommentsDTO
            {
                UserId = 1001,
                PageId = 2001,
                Location = "Location 1",
                CommentText = "This is the first comment"
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewComments(comments)).Throws(ex);
            var resultTask = _controller.CreateNewComments(comments);
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
