using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chuongnh.Areas.Admin.Models
{
    public class CreatePostViewModel
    {// manage 
        public string UserId { get; set; }
        [AllowHtml]
        public string PostContent { get; set; }
        public string PostTitle { get; set; }
        public Guid CategoryId { get; set; }
        public string Decsription { get; set; }
    }
    public class UpdatePostViewModel
    {
        public Guid Id { get; set; }
        // manage 
        public string UserId { get; set; }
        [AllowHtml]
        public string PostContent { get; set; }
        public string PostTitle { get; set; }
        public Guid CategoryId { get; set; }
        public string Decsription { get; set; }
    }

    public class ChangeImagePostViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
    }
}