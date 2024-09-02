using BusinessObject.DTO;
using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CommentsDAO
    {
        private readonly DBContext _dBContext;
        public Comments cmt { get; set; } = new Comments();

        public CommentsDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddComments(CommentsDTO comments)
        {
            try
            {
                if (comments == null)
                {
                    throw new ArgumentNullException(nameof(comments), "CommentsDTO cannot be null.");
                }

                cmt.PageId = comments.PageId;
                cmt.Status = "1";
                cmt.Location = comments.Location;
                cmt.UserId = comments.UserId;
                cmt.CommentText = comments.CommentText;
                cmt.Timestamp = DateTime.Now;

                _dBContext.Comment.Add(cmt);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding comments: {ex.Message}", ex);
            }
        }

        public async Task<List<Comments>> GetAllComments()
        {
            try
            {
                var comments = await _dBContext.Comment.ToListAsync();
                return comments;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting comments: {ex.Message}", ex);
            }
        }
    }
}
