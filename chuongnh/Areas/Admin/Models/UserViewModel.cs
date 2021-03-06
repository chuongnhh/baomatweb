﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace chuongnh.Areas.Admin.Models
{
    public class UserViewModel
    {
    }

    public class ChangeRoleUserViewModel
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
    }
    public class CreateUserViewModel
    {
        public CreateUserViewModel()
        {
        }
        [Required]
        [EmailAddress]
        [Display(Name = "Địa chỉ email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // option
        [Display(Name = "Họ tên")]
        [System.Web.Mvc.AllowHtml]
        public string FullName { get; set; }
    }

}