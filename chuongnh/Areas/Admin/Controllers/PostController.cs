using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongnh.Models;
using chuongnh.Areas.Admin.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.IO;
using chuongnh.CodeHelper;
using System.Drawing;

namespace chuongnh.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Post
        public ActionResult Index()
        {
            var model = db.Posts.ToList();
            return View(model);
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Admin/Post/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new ApplicationPost
                {
                    PostContent = model.PostContent,
                    UserId = User.Identity.GetUserId(),
                    CategoryId = model.CategoryId,
                    PostTitle = model.PostTitle,
                    Decsription = model.Decsription
                };

                db.Posts.Add(post);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", model.CategoryId);
            return View(model);
        }

        // GET: Admin/Post/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var post = await db.Posts.FindAsync(id);
            var model = new UpdatePostViewModel
            {
                Id = post.Id,
                CategoryId = post.CategoryId,
                PostContent = post.PostContent,
                UserId = post.UserId,
                PostTitle = post.PostTitle,
                Decsription = post.Decsription
            };
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", model.CategoryId);
            return View(model);
        }

        // POST: Admin/Post/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(UpdatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = await db.Posts.FindAsync(model.Id);

                post.PostContent = model.PostContent;
                post.CategoryId = model.CategoryId;
                post.UserId = User.Identity.GetUserId();
                post.UpdatedDate = DateTime.Now;
                post.PostTitle = model.PostTitle;
                post.Decsription = model.Decsription;

                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", model.CategoryId);
            return View();
        }

        // GET: Admin/Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Post/Delete/5
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

        public async Task<ActionResult> ChangeImage(Guid? id)
        {
            //CurrentAction.currentAction = "Post";
            var post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var model = new ChangeImagePostViewModel
            {
                Id = post.Id,
                Image = post.Image
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeImage(ChangeImagePostViewModel model)
        {
            //CurrentAction.currentAction = "Post";
            if (ModelState.IsValid)
            {
                var post = await db.Posts.FindAsync(model.Id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                try
                {
                    string image = "";
                    foreach (string item in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[item];
                        if (file != null && file.ContentLength > 0)
                        {
                            //Định nghĩa đường dẫn lưu file trên server
                            //ở đây mình lưu tại đường dẫn yourdomain/Uploads/
                            var originalDirectory = new DirectoryInfo(string.Format("{0}Uploads\\Posts\\", Server.MapPath(@"\")));
                            //Lưu trữ hình ảnh theo từng tháng trong năm
                            var datePath = DateTime.Now.ToString("yyyy-MM");
                            string pathString = Path.Combine(originalDirectory.ToString(), datePath);
                            bool isExists = Directory.Exists(pathString);
                            if (!isExists) Directory.CreateDirectory(pathString);
                            var path = string.Format("{0}\\{1}", pathString, file.FileName);
                            string newFileName = file.FileName;
                            //lấy đường dẫn lưu file sau khi kiểm tra tên file trên server có tồn tại hay không
                            var newPath = ImageHelper.GetNewPathForDupes(path, ref newFileName);
                            string serverPath = string.Format("/{0}/{1}/{2}", "Uploads", "Posts", datePath, newFileName);
                            //Lưu hình ảnh Resize từ file sử dụng file.InputStream
                            ImageHelper.SaveResizeImage(Image.FromStream(file.InputStream), 600, newPath);
                            image = "/Uploads/Posts/" + datePath + "/" + newFileName;
                        }
                    }
                    if (string.IsNullOrEmpty(image) == false)
                    {
                        // xóa image cũ nếu thay image mới
                        string deletePath = Request.MapPath(post.Image);
                        if (System.IO.File.Exists(deletePath) && post.Image != "/Uploads/Posts/def.jpg")
                        {
                            System.IO.File.Delete(deletePath);
                        }
                        post.Image = image;
                        post.UpdatedDate = DateTime.Now;
                    }
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Post", null);
                }
                catch (Exception)
                {

                }
            }
            return View(model);
        }

    }
}
