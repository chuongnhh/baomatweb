using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chuongnh.Models;
using chuongnh.Areas.Admin.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace chuongnh.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/User
        public ActionResult Index()
        {
            var model = db.Users;
            ViewBag.Roles = db.Roles.AsEnumerable();
            return View(model.ToList());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // POST: Admin/User/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(CreateUserViewModel model)
        {
            //CurrentAction.currentAction = "User";
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName=model.FullName
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Xác nhận tài khoản của bạn", "Vui lòng nhấp vào liên kết <a href=\"" + callbackUrl + "\">này</a> để xác nhận tài khoản của bạn.");

                    return RedirectToAction("Index", "User", null);//Json(new { status = true, message = "Người dùng đã được tạo thành công." });
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);//Json(new { status = false, message = "Đã xảy ra lỗi trong khi xử lý." });
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult ChangeRole(string id)
        {
            //CurrentAction.currentAction = "User";
            var model = db.Roles.ToList();
            ViewBag.User = db.Users.Find(id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeRole(string Id, string RoleId)
        {
            var user = db.Users.Find(Id);
            if (user != null)
            {
                // huy quyen
                if (user.Roles.Any(x => x.RoleId == RoleId))
                {
                    user.Roles.Remove(user.Roles.FirstOrDefault(x => x.RoleId == RoleId));

                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "User", null);//Json(new { status = true, value = false, message = "Đã hủy quyền thành công." });
                }
                else
                {
                    user.Roles.Add(new IdentityUserRole
                    {
                        RoleId = RoleId,
                        UserId = Id
                    });
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "User", null);//Json(new { status = true, value = true, message = "Đã thêm quyền thành công." });
                }
            }
            return View();//Json(new { status = false, message = "Xảy ra lỗi trong khi xử lý." });
        }

        // POST: Admin/User/Edit/5
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

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/User/Delete/5
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
