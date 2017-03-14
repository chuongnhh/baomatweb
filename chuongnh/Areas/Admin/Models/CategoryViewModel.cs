using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace chuongnh.Areas.Admin.Models
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "Tên chuyên mục")]
        public string CategoryName { get; set; }
        // manage 
        [Display(Name = "Người khởi tạo")]
        public string UserId { get; set; }
    }

    public class UpdateCategoryViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên chuyên mục")]
        public string CategoryName { get; set; }
        // manage 
        [Display(Name = "Người khởi tạo")]
        public string UserId { get; set; }
    }
}