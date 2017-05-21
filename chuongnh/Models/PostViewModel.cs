using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chuongnh.Models
{
    public class CommentPostViewModel
    {
        public string UserId { get; set; }
        public Guid PostId { get; set; }
        public string Comment { get; set; }
    }
}