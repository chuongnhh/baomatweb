using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongnh.Models;
using chuongnh.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace chuongnh.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var model = db.Categories
                .OrderByDescending(x => x.CreatedDate)
                .ToList<ApplicationCategory>();
            return View(model);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationCategory category = new ApplicationCategory
                {
                    CategoryName = model.CategoryName,
                    UserId = User.Identity.GetUserId()
                };
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Admin/Category/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var model = new UpdateCategoryViewModel
            {
                CategoryName = category.CategoryName,
                Id = category.Id,
                UserId = category.UserId
            };
            return View(model);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(UpdateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await db.Categories.FindAsync(model.Id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                category.CategoryName = model.CategoryName;
                category.MetaTitle = CodeHelper.StringHelper.ToUnsignString(model.CategoryName);
                category.UserId = User.Identity.GetUserId();
                category.UpdatedDate = DateTime.Now;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
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
