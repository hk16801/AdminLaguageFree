using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Service
{
    public class CommentsRepository : CommentsIRepository
    {
        private readonly CommentsDAO _commentsDAO;

        public CommentsRepository(CommentsDAO commentsDAO)
        {
            _commentsDAO = commentsDAO;
        }
        public Task NewComments(CommentsDTO comments)
        {
            return _commentsDAO.AddComments(comments);
        }
        public Task<List<Comments>> GetAllComments()
        {
            return _commentsDAO.GetAllComments();
        }
    }
}
