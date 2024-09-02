using AutoFixture;
using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess;
using DataAccess.DAO;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.DAOTest
{
    [TestClass]
    public class CommentsDAOTest
    {
        private Fixture _fixture;
        private CommentsDAO _commentDao;
        private DBContext _context;
        private Mock<DBContext> _contextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _contextMock = new Mock<DBContext>(new DbContextOptions<DBContext>());
            _fixture = new Fixture();
            _context = new DBContext(new DbContextOptions<DBContext>());
            _commentDao = new CommentsDAO(_context);
        }
        public void ClearAllData()
        {
            ClearData<Users>();
            ClearData<TranslationHistorys>();
            ClearData<Settings>();
            ClearData<Pages>();
            ClearData<LanguageLogs>();
            ClearData<Comments>();
            ClearData<Rates>();
            ClearData<Roles>();
            ClearData<Accounts>();
            ClearData<AccessLogs>();

            _context.SaveChanges();
        }

        private void ClearData<T>() where T : class
        {
            var entities = _context.Set<T>();
            _context.RemoveRange(entities);
        }

        [TestMethod]
        public async Task AddComments_NewSuccess()
        {
            CommentsDTO commentDTO = new CommentsDTO
            {
                PageId = 1,
                Location = "Test Location",
                UserId = 1,
                CommentText = "Test Comment",
            };

            await _commentDao.AddComments(commentDTO);

            var addedComment = await _context.Comment.FirstOrDefaultAsync();
            addedComment.Should().NotBeNull();
            addedComment.PageId.Should().Be(commentDTO.PageId);
            addedComment.Location.Should().Be(commentDTO.Location);
            addedComment.UserId.Should().Be(commentDTO.UserId);
            addedComment.CommentText.Should().Be(commentDTO.CommentText);
            ClearAllData();
        }

        [TestMethod]
        public async Task AddComments_Fail_1()
        {
            try
            {
                CommentsDTO commentDTO = null;
                await _commentDao.AddComments(commentDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding comments: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task AddComments_Fail_2()
        {

            try
            {
                CommentsDTO commentDTO = new CommentsDTO
                {
                    PageId = 1,
                    Location = "Test Location",
                    UserId = 1,
                    CommentText = "Test Comment",
                };

                var ex = new InvalidOperationException("AccessLogsDTO exception");
                _contextMock.Setup(m => m.AccessLog).Throws(ex);
                var commentDao = new CommentsDAO(_contextMock.Object);
                await commentDao.AddComments(commentDTO);
            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while adding comments: ");
            }
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllComments_Success()
        {
            Comments commentDTO = new Comments
            {
                UserId = 1,
                PageId = 1,
                Location = "Test Location",
                Status = "1",
                CommentText = "Test Comment",
                Timestamp = DateTime.Now,
            };
            Comments commentDTO2 = new Comments
            {
                UserId = 1,
                PageId = 1,
                Location = "Test Location",
                Status = "1",
                CommentText = "Test Comment",
                Timestamp = DateTime.Now,
            };
            _context.Add(commentDTO);
            _context.Add(commentDTO2);
            await _context.SaveChangesAsync();

            List<Comments> CommentsList = new List<Comments>();
            CommentsList.Add(commentDTO);
            CommentsList.Add(commentDTO2);

            var result = await _commentDao.GetAllComments();
            result.Should().BeEquivalentTo(CommentsList);
            ClearAllData();
        }

        [TestMethod]
        public async Task GetAllComments_ReturnsEx()
        {

            try
            {
                var ex = new InvalidOperationException("CommentDAO exception");
                _contextMock.Setup(m => m.Comment).Throws(ex);
                var commentDao = new CommentsDAO(_contextMock.Object);
                await commentDao.GetAllComments();

            }
            catch (Exception ex)
            {
                ex.Message.Should().StartWith("Error occurred while getting comments: ");
            }
            ClearAllData();
        }

    }
}
