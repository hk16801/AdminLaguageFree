using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CommentsDTO
    {
        public int UserId { get; set; }

        public int PageId { get; set; }
        public string Location { get; set; }
        public string CommentText { get; set; }

    }
}
