using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongnh.Models;

namespace chuongnh.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = db.Posts
                .OrderByDescending(x=>x.CreatedDate)
                .Take(10);

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult _RightMenu()
        {
            ViewBag.Categories = db.Categories.OrderByDescending(x => x.CreatedDate).Take(10);
            ViewBag.Posts = db.Posts.OrderByDescending(x => x.CreatedDate).Take(10);
            return View();
        }

        public ActionResult _Footer()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _MenuCategoryPartial()
        {
            var model = db.Categories.ToList();

            return PartialView(model);
        }
    }
}