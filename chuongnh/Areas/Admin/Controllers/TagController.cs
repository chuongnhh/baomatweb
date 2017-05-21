using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongnh.Models;

namespace chuongnh.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Tag
        public ActionResult Index()
        {
            var model = db.Tags.ToList();
            return View(model);
        }

        // GET: Admin/Tag/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Tag/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Tag/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Tag/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
