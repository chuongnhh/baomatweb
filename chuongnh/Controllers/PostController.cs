using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongnh.Models;
using System.Threading.Tasks;

namespace chuongnh.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Post
        public async Task<ActionResult> Index(Guid id)
        {
            var model = await db.Posts
                .FindAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(CommentPostViewModel c)
        {
            if (ModelState.IsValid)
            {
                var model = new ApplicationComment
                {
                    CommentContent = c.Comment,
                    UserId = c.UserId,
                    PostId = c.PostId
                };

                db.Comments.Add(model);
                await db.SaveChangesAsync();
                c.PostId = model.Id;
                return RedirectToAction("Index", "Post", model.PostId);
            }
            return HttpNotFound();
        }

        //[HttpPost]
        //public async Task<JsonResult> Comment(CommentPostViewModel c)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var model = new ApplicationComment
        //        {
        //            CommentContent = c.Comment,
        //            UserId = c.UserId,
        //            PostId = c.PostId
        //        };

        //        db.Comments.Add(model);
        //        await db.SaveChangesAsync();
        //        return Json(new { status = true, Fullname = model.User.FullName, PostId = model.Id, Comment = model.CommentContent }, JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(new { status = false }, JsonRequestBehavior.AllowGet);
        //}
    }
}