using Admin_LanguageFree.Controllers;
using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reponsitory;
using Reponsitory.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.ControllerTest
{
    [TestClass]
    public class UsersControllerTest
    {
        private Mock<UsersIRepository> _repositoryMock;
        private Fixture _fixture;
        private UsersController _controller;
        private Mock<IWebHostEnvironment> mockWebHostEnvironment;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<UsersIRepository>();
            mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            _fixture = new Fixture();
            _controller = new UsersController(_repositoryMock.Object, mockWebHostEnvironment.Object);
        }
        [TestMethod]
        public async Task GetAllUsers_Success()
        {
            List<Users> users = new List<Users>
            {
                new Users
                {
                    UserId = 1,
                    FullName = "John Doe",
                    ImageUser = "avatar.jpg",
                    Email = "john@example.com",
                    Phone = "123-456-7890",
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Gender = "Male",
                    National = "American",
                    Timestamp = DateTime.Now
                },
                new Users
                {
                    UserId = 2,
                    FullName = "Jane Smith",
                    ImageUser = "profile.png",
                    Email = "jane@example.com",
                    Phone = "987-654-3210",
                    DateOfBirth = new DateTime(1985, 10, 25),
                    Gender = "Female",
                    National = "Canadian",
                    Timestamp = DateTime.Now
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllUsers()).Returns(Task.FromResult(users));
            var resultTask = _controller.GetAllUsers();
            var result = await resultTask;
            if (result.Result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(users);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllUsers_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllUsers()).Throws(ex);
            var resultTask = _controller.GetAllUsers();
            var result = await resultTask;
            if (result.Result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllUser_BadRequest()
        {
            List<Users> users = null;
            _repositoryMock.Setup(repo => repo.GetAllUsers()).Returns(Task.FromResult(users));
            var resultTask = _controller.GetAllUsers();
            var result = await resultTask;
            if (result.Result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("User Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateUser_Success()
        {
            UsersDTO users = new UsersDTO
            {
                UserId = 2,
                FullName = "Jane Smith",
                ImageUser = "1.png",
                Email = "jane@example.com",
                Phone = "987-654-3210",
                DateOfBirth = new DateTime(1985, 10, 25),
                Gender = "Female",
                National = "Canadian",
            };
            UserTempDTO users1 = new UserTempDTO
            {
                UserId = 2,
                FullName = "Jane Smith",
                Email = "jane@example.com",
                Phone = "987-654-3210",
                DateOfBirth = new DateTime(1985, 10, 25),
                Gender = "Female",
                National = "Canadian",
            };
            _repositoryMock.Setup(repo => repo.NewUsers(users)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewUser(users1);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("User created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateUser_Fail()
        {
            UsersDTO users = new UsersDTO
            {
                UserId = 2,
                FullName = "Jane Smith",
                ImageUser = "1.png",
                Email = "jane@example.com",
                Phone = "987-654-3210",
                DateOfBirth = new DateTime(1985, 10, 25),
                Gender = "Female",
                National = "Canadian",
            };
            UserTempDTO users1 = new UserTempDTO
            {
                UserId = 2,
                FullName = "Jane Smith",
                Email = "jane@example.com",
                Phone = "987-654-3210",
                DateOfBirth = new DateTime(1985, 10, 25),
                Gender = "Female",
                National = "Canadian",
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewUsers(It.Is<UsersDTO>(u => u.UserId == 2))).ThrowsAsync(ex);
            var resultTask = _controller.CreateNewUser(users1);
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
        public async Task GetAllUserWithAccountStatus_Success()
        {
            int status = 1;
            string roleid = "1";
            List<Users> users = new List<Users>
            {
                new Users
                {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now
                },
                new Users
                {
                UserId = 2,
                FullName = "Jane Smith",
                ImageUser = "profile.png",
                Email = "jane@example.com",
                Phone = "987-654-3210",
                DateOfBirth = new DateTime(1985, 10, 25),
                Gender = "Female",
                National = "Canadian",
                Timestamp = DateTime.Now
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllUserWithAccountStatus(roleid, status)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetAllUserWithAccountStatus(roleid, status);
            var result = await resultTask;
            if (result.Result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(users);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllUserWithAccountStatus_Fail()
        {
            int status = 1;
            string roleid = "1";
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllUserWithAccountStatus(roleid, status)).Throws(ex);
            var resultTask = _controller.GetAllUserWithAccountStatus(roleid, status);
            var result = await resultTask;
            if (result.Result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllUserWithAccountStatus_BadRequest()
        {
            int status = 1;
            string roleid = "1";
            List<Users> users = null;
            _repositoryMock.Setup(repo => repo.GetAllUserWithAccountStatus(roleid, status)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetAllUserWithAccountStatus(roleid, status);
            var result = await resultTask;
            if (result.Result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("User Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllUserWithStatus_Success()
        {
            int status = 1;
            List<Users> users = new List<Users>
            {
                new Users
                {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now
                },
                new Users
                {
                UserId = 2,
                FullName = "Jane Smith",
                ImageUser = "profile.png",
                Email = "jane@example.com",
                Phone = "987-654-3210",
                DateOfBirth = new DateTime(1985, 10, 25),
                Gender = "Female",
                National = "Canadian",
                Timestamp = DateTime.Now
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllUserWithStatus(status)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetAllUserWithStatus(status);
            var result = await resultTask;
            if (result.Result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(users);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllUserWithStatus_Fail()
        {
            int status = 1;
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllUserWithStatus(status)).Throws(ex);
            var resultTask = _controller.GetAllUserWithStatus(status);
            var result = await resultTask;
            if (result.Result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllUserWithStatus_BadRequest()
        {
            int status = 1;
            List<Users> users = null;
            _repositoryMock.Setup(repo => repo.GetAllUserWithStatus(status)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetAllUserWithStatus(status);
            var result = await resultTask;
            if (result.Result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("User Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByUserVoice_Success()
        {
            int id = 1;
            UserVoiceDTO userVoice = new UserVoiceDTO
            {
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 5, 15)
            };
            _repositoryMock.Setup(repo => repo.GetByUserVoice(id)).Returns(Task.FromResult(userVoice));
            var resultTask = _controller.GetByUserVoice(id);
            var result = await resultTask;
            if (result.Result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(userVoice);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByUserVoice_Fail()
        {
            int id = 1;
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetByUserVoice(id)).Throws(ex);
            var resultTask = _controller.GetByUserVoice(id);
            var result = await resultTask;
            if (result.Result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByUserVoice_BadRequest()
        {
            int id = 1;
            UserVoiceDTO userVoice = null;
            _repositoryMock.Setup(repo => repo.GetByUserVoice(id)).Returns(Task.FromResult(userVoice));
            var resultTask = _controller.GetByUserVoice(id);
            var result = await resultTask;
            if (result.Result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("User Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByAccount_Success()
        {
            string username = "John Doe";
            Users users = new Users
            {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now
            };
            _repositoryMock.Setup(repo => repo.GetByAccount(username)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetByAccount(username);
            var result = await resultTask;
            if (result.Result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(users);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByAccount_Fail()
        {
            string username = "John Doe";
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetByAccount(username)).Throws(ex);
            var resultTask = _controller.GetByAccount(username);
            var result = await resultTask;
            if (result.Result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByAccount_BadRequest()
        {
            string username = "John Doe";
            Users users = null;
            _repositoryMock.Setup(repo => repo.GetByAccount(username)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetByAccount(username);
            var result = await resultTask;
            if (result.Result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("User Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByAccountByID_Success()
        {
            int id = 1;
            Users users = new Users
            {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now
            };
            _repositoryMock.Setup(repo => repo.GetByAccountByID(id)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetByAccountByID(id);
            var result = await resultTask;
            if (result.Result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(users);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByAccountByID_Fail()
        {
            int id = 1;
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetByAccountByID(id)).Throws(ex);
            var resultTask = _controller.GetByAccountByID(id);
            var result = await resultTask;
            if (result.Result is ObjectResult objectResult)
            {
                objectResult.StatusCode.Should().Be(500);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetByAccountByID_BadRequest()
        {
            int id = 1;
            Users users = null;
            _repositoryMock.Setup(repo => repo.GetByAccountByID(id)).Returns(Task.FromResult(users));
            var resultTask = _controller.GetByAccountByID(id);
            var result = await resultTask;
            if (result.Result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("User Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CheckUserExist_Success()
        {
            string userName = "John Doe";
            CheckUser check = new CheckUser
            {
                IsChecked = true,
            };
            Users users = new Users
            {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now
            };
            _repositoryMock.Setup(repo => repo.CheckUserExist(userName)).Returns(Task.FromResult(true));
            var resultTask = _controller.CheckUserExist(userName);
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(check);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CheckUserExist_False()
        {
            string userName = "John Doe";
            CheckUser check = new CheckUser
            {
                IsChecked = false,
            };
            Users users = new Users
            {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now
            };
            _repositoryMock.Setup(repo => repo.CheckUserExist(userName)).Returns(Task.FromResult(false));
            var resultTask = _controller.CheckUserExist(userName);
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(check);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CheckUserExist_Fail()
        {
            string userName = "John Doe";
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.CheckUserExist(userName)).Throws(ex);
            var resultTask = _controller.CheckUserExist(userName);
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
        public async Task UpdateUser_WithImage_Success()
        {
            var model = new AddUserDTO
            {
                UserTempDTO = new UserTempDTO
                {
                    UserId = 1,
                    FullName = "John Doe",
                    Email = "john@example.com",
                    Phone = "123456789",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    National = "US",
                    isPickImage = true
                },
                UploadModel = new ImageUploadModel
                {
                    ImageFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake image data")), 0, 0, "Data", "fakeimage.jpg")
                }
            };
            Users users = new Users
            {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now

            };
            mockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "images"));

            _repositoryMock.Setup(repo => repo.GetByUserTemp(model.UserTempDTO.UserId)).Returns(Task.FromResult(users));
            var resultTask = await _controller.UpdateUser(model);
            var result = (ObjectResult)resultTask;
            result.StatusCode.Should().Be(200);
            result.Value.Should().Be("User updated successfully");
        }
        [TestMethod]
        public async Task UpdateUser_WithImage_NoImage_Success()
        {
            var model = new AddUserDTO
            {
                UserTempDTO = new UserTempDTO
                {
                    UserId = 1,
                    FullName = "John Doe",
                    Email = "john@example.com",
                    Phone = "123456789",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    National = "US",
                    isPickImage = false
                },
                UploadModel = new ImageUploadModel
                {
                    ImageFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake image data")), 0, 0, "Data", "fakeimage.jpg")
                }
            };
            Users users = new Users
            {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now

            };
            mockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "images"));

            _repositoryMock.Setup(repo => repo.GetByUserTemp(model.UserTempDTO.UserId)).Returns(Task.FromResult(users));
            var resultTask = await _controller.UpdateUser(model);
            var result = (ObjectResult)resultTask;
            result.StatusCode.Should().Be(200);
            result.Value.Should().Be("User updated without image successfully");
        }

        [TestMethod]
        public async Task UpdateUser_WithUnsupportedImageFormat()
        {
            var model = new AddUserDTO
            {
                UserTempDTO = new UserTempDTO
                {
                    UserId = 1,
                    FullName = "John Doe",
                    Email = "john@example.com",
                    Phone = "123456789",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    National = "US",
                    isPickImage = true
                },
                UploadModel = new ImageUploadModel
                {
                    ImageFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake image data")), 0, 0, "Data", "fakeimage.bmp")
                }
            };

            var resultTask = await _controller.UpdateUser(model);

            var result = (ObjectResult)resultTask;
            result.StatusCode.Should().Be(500);
        }

        [TestMethod]
        public async Task UpdateUser_InternalServerError()
        {
            var model = new AddUserDTO
            {
                UserTempDTO = new UserTempDTO
                {
                    UserId = 1,
                    FullName = "John Doe",
                    Email = "john@example.com",
                    Phone = "123456789",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    National = "US",
                    isPickImage = true
                },
                UploadModel = new ImageUploadModel
                {
                    ImageFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake image data")), 0, 0, "Data", "fakeimage.bmp")
                }
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetByUserTemp(model.UserTempDTO.UserId)).ThrowsAsync(ex);
            var resultTask = await _controller.UpdateUser(model);
            var result = (ObjectResult)resultTask;
            result.StatusCode.Should().Be(500);
        }
        [TestMethod]
        public async Task UpdateUser_WhenImageFolderDoesNotExist_ShouldReturnSuccess()
        {
            string mockDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "images");
            mockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(mockDirectory);
            if (Directory.Exists(mockDirectory))
            {
                Directory.Delete(mockDirectory, true);
            }
            var model = new AddUserDTO
            {
                UserTempDTO = new UserTempDTO
                {
                    UserId = 1,
                    FullName = "John Doe",
                    Email = "john@example.com",
                    Phone = "123456789",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    National = "US",
                    isPickImage = true
                },
                UploadModel = new ImageUploadModel
                {
                    ImageFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake image data")), 0, 0, "Data", "fakeimage.jpg")
                }
            };
            Users users = new Users
            {
                UserId = 1,
                FullName = "John Doe",
                ImageUser = "avatar.jpg",
                Email = "john@example.com",
                Phone = "123-456-7890",
                DateOfBirth = new DateTime(1990, 5, 15),
                Gender = "Male",
                National = "American",
                Timestamp = DateTime.Now

            };
            var resultTask = await _controller.UpdateUser(model);
            var result = (ObjectResult)resultTask;
            result.StatusCode.Should().Be(200);
            result.Value.Should().Be("User updated successfully");
            
        }






    }
}
