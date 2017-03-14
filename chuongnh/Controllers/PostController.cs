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
    }
}