using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface CommentsIRepository
    {
        Task NewComments(CommentsDTO comments);
        Task<List<Comments>> GetAllComments();

    }
}
