using System.Web.Mvc;

namespace chuongnh.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              "AdminTag",
              "quan-tri/the",
              new { controller = "Tag", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
          );
            context.MapRoute(
              "AdminComment",
              "quan-tri/binh-luan",
              new { controller = "Comment", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
          );
            context.MapRoute(
              "AdminPost",
              "quan-tri/bai-viet",
              new { controller = "Post", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
          );
            context.MapRoute(
              "AdminPostCreate",
              "quan-tri/bai-viet/them",
              new { controller = "Post", action = "Create", id = UrlParameter.Optional },
              namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
          );
            context.MapRoute(
              "AdminPostEdit",
              "quan-tri/bai-viet/sua/{id}",
              new { controller = "Post", action = "Edit", id = UrlParameter.Optional },
              namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
          );
            context.MapRoute(
             "AdminPostChangeImage",
             "quan-tri/bai-viet/doi-anh/{id}",
             new { controller = "Post", action = "ChangeImage", id = UrlParameter.Optional },
             namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
         );
            context.MapRoute(
               "AdminCategory",
               "quan-tri/chuyen-muc",
               new { controller = "Category", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
           );
            context.MapRoute(
              "AdminCategoryCreate",
              "quan-tri/chuyen-muc/them",
              new { controller = "Category", action = "Create", id = UrlParameter.Optional },
              namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
          );
            context.MapRoute(
             "AdminCategoryEdit",
             "quan-tri/chuyen-muc/sua/{id}",
             new { controller = "Category", action = "Edit", id = UrlParameter.Optional },
             namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
         );
            context.MapRoute(
                "AdminUser",
                "quan-tri/nguoi-dung",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
            );

            context.MapRoute(
               "AdminUserCreate",
               "quan-tri/nguoi-dung/them",
               new { controller = "User", action = "Create", id = UrlParameter.Optional },
               namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               "AdminUserEdit",
               "quan-tri/nguoi-dung/sua/{id}",
               new { controller = "User", action = "Edit", id = UrlParameter.Optional },
               namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               "AdminUserChangeRole",
               "quan-tri/nguoi-dung/sua-quyen/{id}",
               new { controller = "User", action = "ChangeRole", id = UrlParameter.Optional },
               namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
           );

            context.MapRoute(
                "AdminHome",
                "quan-tri",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "chuongnh.Areas.Admin.Controllers" }
            );
        }
    }
}