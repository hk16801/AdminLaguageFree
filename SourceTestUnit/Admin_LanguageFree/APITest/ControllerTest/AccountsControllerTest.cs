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
    public class AccountsControllerTest
    {
        private Mock<AccountsIRepository> _repositoryMock;
        private Fixture _fixture;
        private AccountsController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<AccountsIRepository>();
            _fixture = new Fixture();
            _controller = new AccountsController(_repositoryMock.Object);
        }
        [TestMethod]
        public async Task GetAllAccounts_Success()
        {
            List<Accounts> accounts = new List<Accounts>
            {
                new Accounts
                {
                AccountId = 1,
                UserId = 123,
                Username = "john_doe",
                Password = "password123",
                RoleId = "user",
                Timestamp = DateTime.Now,
                Status = 1
                },
                new Accounts
                {
                AccountId = 2,
                UserId = 456,
                Username = "jane_smith",
                Password = "password456",
                RoleId = "admin",
                Timestamp = DateTime.Now,
                Status = 1
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllAccounts()).Returns(Task.FromResult(accounts));
            var resultTask = _controller.GetAllAccounts();
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(accounts);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllAccounts_Fail()
        {
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllAccounts()).Throws(ex);
            var resultTask = _controller.GetAllAccounts();
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
        public async Task GetAllAccounts_BadRequest()
        {
            List<Accounts> accounts = null;
            _repositoryMock.Setup(repo => repo.GetAllAccounts()).Returns(Task.FromResult(accounts));
            var resultTask = _controller.GetAllAccounts();
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Account Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task CreateNewAccounts_Success()
        {
            AccountsDTO accounts = new AccountsDTO
            {
                UserId = 123,
                Username = "john_doe",
                Password = "password123",
                RoleId = "user",
                Status = 1
            };
            _repositoryMock.Setup(repo => repo.NewAccounts(accounts)).Returns(Task.CompletedTask);
            var result = await _controller.CreateNewAccounts(accounts);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Account created successfully", okResult.Value);
        }
        [TestMethod]
        public async Task CreateNewAccounts_Fail()
        {
            AccountsDTO accounts = new AccountsDTO
            {
                UserId = 123,
                Username = "john_doe",
                Password = "password123",
                RoleId = "user",
                Status = 1
            };
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.NewAccounts(accounts)).Throws(ex);
            var resultTask = _controller.CreateNewAccounts(accounts);
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
        public async Task GetAllAccountsWithStatusTwo_Success()
        {
            int status = 1;
            List<Accounts> accounts = new List<Accounts>
            {
                new Accounts
                {
                AccountId = 1,
                UserId = 123,
                Username = "john_doe",
                Password = "password123",
                RoleId = "user",
                Timestamp = DateTime.Now,
                Status = 1
                },
                new Accounts
                {
                AccountId = 2,
                UserId = 456,
                Username = "jane_smith",
                Password = "password456",
                RoleId = "admin",
                Timestamp = DateTime.Now,
                Status = 1
                },
            };
            _repositoryMock.Setup(repo => repo.GetAllAccountsWithStatus(status)).Returns(Task.FromResult(accounts));
            var resultTask = _controller.GetAllAccountsWithStatusTwo(status);
            var result = await resultTask;
            if (result is OkObjectResult okResult)
            {
                var value = okResult.Value;
                value.Should().BeEquivalentTo(accounts);
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }
        [TestMethod]
        public async Task GetAllAccountsWithStatusTwo_Fail()
        {
            int status = 1;
            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.GetAllAccountsWithStatus(status)).Throws(ex);
            var resultTask = _controller.GetAllAccountsWithStatusTwo(status);
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
        public async Task GetAllAccountsWithStatusTwo_BadRequest()
        {
            int status = 1;
            List<Accounts> accounts = null;
            _repositoryMock.Setup(repo => repo.GetAllAccountsWithStatus(status)).Returns(Task.FromResult(accounts));
            var resultTask = _controller.GetAllAccountsWithStatusTwo(status);
            var result = await resultTask;
            if (result is BadRequestObjectResult badRequest)
            {
                var value = badRequest;
                value.StatusCode.Should().Be(400);
                value.Value.Should().Be("Account Not Found");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType().Name}");
            }
        }

        [TestMethod]
        public async Task RemoveAccount_Success()
        {
            int id = 1;
            _repositoryMock.Setup(repo => repo.RemoveAccount(id)).Returns(Task.CompletedTask);

            var result = await _controller.RemoveAccount(id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Account delete successfully", okResult.Value);
        }

        [TestMethod]
        public async Task RemoveAccount_BadRequest()
        {
            int id = 1;
            _repositoryMock.Setup(repo => repo.RemoveAccount(id)).Throws(new Exception("Simulated exception"));

            var result = await _controller.RemoveAccount(id);

            var statusCodeResult = result as ObjectResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
            statusCodeResult.Value.Should().Be("Internal server error");
        }

        [TestMethod]
        public async Task ActiveAccount_Success()
        {
            int id = 1;
            _repositoryMock.Setup(repo => repo.ActiveAccount(id)).Returns(Task.CompletedTask);

            var result = await _controller.ActiveAccount(id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual("Account active successfully", okResult.Value);
        }

        [TestMethod]
        public async Task ActiveAccount_BadRequest()
        {
            int id = 1;
            _repositoryMock.Setup(repo => repo.ActiveAccount(id)).Throws(new Exception("Simulated exception"));

            var result = await _controller.ActiveAccount(id);

            var statusCodeResult = result as ObjectResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
            statusCodeResult.Value.Should().Be("Internal server error");
        }
        [TestMethod]
        public async Task CheckAccountExist_Success()
        {
            string userName = "John Doe";
            CheckUser check = new CheckUser
            {
                IsChecked = true,
            };
            new Accounts
            {
                AccountId = 1,
                UserId = 123,
                Username = "john_doe",
                Password = "password123",
                RoleId = "user",
                Timestamp = DateTime.Now,
                Status = 1
            };
            _repositoryMock.Setup(repo => repo.CheckAccountExist(userName)).Returns(Task.FromResult(true));
            var resultTask = _controller.CheckAccountExist(userName);
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
        public async Task CheckAccountExist_False()
        {
            string userName = "John Doe";
            CheckUser check = new CheckUser
            {
                IsChecked = false,
            };
            new Accounts
            {
                AccountId = 1,
                UserId = 123,
                Username = "john_doe",
                Password = "password123",
                RoleId = "user",
                Timestamp = DateTime.Now,
                Status = 1
            };
            _repositoryMock.Setup(repo => repo.CheckAccountExist(userName)).Returns(Task.FromResult(false));
            var resultTask = _controller.CheckAccountExist(userName);
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
        public async Task GetAccountsToSession_Success()
        {
            string username = "john_doe";
            int userId = 123;
            _repositoryMock.Setup(repo => repo.GetAccountsToSession(username)).ReturnsAsync(userId);
            var resultTask = await _controller.GetAccountsToSession(username);
            var result = (OkObjectResult)resultTask;
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeEquivalentTo(new { UserId = userId });
        }
        [TestMethod]
        public async Task CheckLogin_Success()
        {
            var login = new LoginDTO
            {
                Username = "john_doe",
                Password = "password123"
            };
            var account = new Accounts
            {
                AccountId = 1,
                UserId = 1,
                Username = "john_doe",
                Password = "password123",
                RoleId = "1",
                Status = 1,
                Timestamp = DateTime.Now
            };
            _repositoryMock.Setup(repo => repo.CheckLogin(login.Username, login.Password)).ReturnsAsync(true);
            _repositoryMock.Setup(repo => repo.GetAccountsToToken(login.Username)).ReturnsAsync(account);

            var resultTask = await _controller.CheckLogin(login);
            var result = (OkObjectResult)resultTask;
            result.StatusCode.Should().Be(200);
            TokenReponse tokenResponse = (TokenReponse)result.Value;
            tokenResponse.Account.Should().BeEquivalentTo(account);
            tokenResponse.AccessToken.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task CheckLogin_Unauthorized()
        {
            var login = new LoginDTO
            {
                Username = "john_doe",
                Password = "password123"
            };

            _repositoryMock.Setup(repo => repo.CheckLogin(login.Username, login.Password)).ReturnsAsync(false);
            var resultTask = await _controller.CheckLogin(login);
            var result = (BadRequestObjectResult)resultTask;
            result.StatusCode.Should().Be(400);
            result.Value.Should().BeEquivalentTo(new { Message = "UnAcc" });
        }

        [TestMethod]
        public async Task CheckLogin_AccountLocked()
        {
            var login = new LoginDTO
            {
                Username = "john_doe",
                Password = "password123"
            };
            var account = new Accounts
            {
                AccountId = 1,
                UserId = 1,
                Username = "john_doe",
                Password = "password123",
                RoleId = "1",
                Status = 2,
                Timestamp = DateTime.Now
            };

            _repositoryMock.Setup(repo => repo.CheckLogin(login.Username, login.Password)).ReturnsAsync(true);
            _repositoryMock.Setup(repo => repo.GetAccountsToToken(login.Username)).ReturnsAsync(account);
            var resultTask = await _controller.CheckLogin(login);
            var result = (BadRequestObjectResult)resultTask;
            result.StatusCode.Should().Be(400);
            result.Value.Should().BeEquivalentTo(new { Message = "Account Locket" });
        }

        [TestMethod]
        public async Task CheckLogin_Unauthorized_InvalidAccount()
        {
            var login = new LoginDTO
            {
                Username = "non_existing_user",
                Password = "password123"
            };

            _repositoryMock.Setup(repo => repo.CheckLogin(login.Username, login.Password)).ReturnsAsync(false);
            _repositoryMock.Setup(repo => repo.GetAccountsToToken(login.Username)).ReturnsAsync((Accounts)null);
            var resultTask = await _controller.CheckLogin(login);
            var result = (BadRequestObjectResult)resultTask;
            result.StatusCode.Should().Be(400);
            result.Value.Should().BeEquivalentTo(new { Message = "UnAcc" });
        }
        [TestMethod]
        public async Task UpdateAccounts_Success()
        {
            int accountId = 1;
            var accountsDTO = new AccountsDTO
            {
                UserId = 123,
                Username = "john_doe",
                Password = "new_password",
                RoleId = "user",
                Status = 1
            };
            _repositoryMock.Setup(repo => repo.UpdateAccounts(accountId, accountsDTO)).ReturnsAsync(true);
            var resultTask = await _controller.UpdateAccounts(accountId, accountsDTO);
            var result = (OkObjectResult)resultTask;
            result.StatusCode.Should().Be(200);
            result.Value.Should().Be("Accounts updated successfully");
        }

        [TestMethod]
        public async Task UpdateAccounts_BadRequest()
        {
            int accountId = 1;
            var accountsDTO = new AccountsDTO
            {
                UserId = 123,
                Username = "john_doe",
                Password = "new_password",
                RoleId = "user",
                Status = 1
            };
            _repositoryMock.Setup(repo => repo.UpdateAccounts(accountId, accountsDTO)).ReturnsAsync(false);
            var resultTask = await _controller.UpdateAccounts(accountId, accountsDTO);
            var result = (NotFoundObjectResult)resultTask;
            result.StatusCode.Should().Be(404);
            result.Value.Should().Be("Accounts not found");
        }

        [TestMethod]
        public async Task UpdateAccounts_Fail()
        {
            int accountId = 1;
            var accountsDTO = new AccountsDTO
            {
                UserId = 123,
                Username = "john_doe",
                Password = "new_password",
                RoleId = "user",
                Status = 1
            };

            var ex = new Exception("Custom Exception");
            _repositoryMock.Setup(repo => repo.UpdateAccounts(accountId, accountsDTO)).Throws(ex);
            var resultTask = _controller.UpdateAccounts(accountId, accountsDTO);
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



    }
}

