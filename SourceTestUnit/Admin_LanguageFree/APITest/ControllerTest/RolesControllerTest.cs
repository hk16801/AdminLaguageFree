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
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APITest.ControllerTest
{
    [TestClass]
    public class RolesControllerTest
    {
        private Mock<RolesIRepository> _repositoryMock;
        private Fixture _fixture;
        private RolesController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<RolesIRepository>();
            _fixture = new Fixture();
            _controller = new RolesController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllRoles_Success()
        {
            List<Roles> roles = new List<Roles>
            {
                new Roles
                {
                     RoleId = 1,
                     RoleName = "Admin"
                },
                new Roles
                {
                     RoleId = 2,
                     RoleName = "User"
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllRoles()).Returns(Task.FromResult(roles));
            var resultTask = _controller.GetAllRoles();
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(roles);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllRoles_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllRoles()).Throws(ex);
            var resultTask = _controller.GetAllRoles();
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
        public async Task GetAllRoles_BadRequest()
        {
            List<Roles> roles = null;
            _repositoryMock.Setup(repo => repo.GetAllRoles()).Returns(Task.FromResult(roles));
            var resultTask = _controller.GetAllRoles();
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Role Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateRoles_Success()
        {
            RolesDTO roles = new RolesDTO
            {
                RoleName = "Admin"
            };
            _repositoryMock.Setup(repo => repo.NewRoles(roles)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewRole(roles);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Role created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreatePages_Fail()
        {
            RolesDTO roles = new RolesDTO
            {
                RoleName = "Admin"
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewRoles(roles)).Throws(ex);
            var resultTask = _controller.CreateNewRole(roles);
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
