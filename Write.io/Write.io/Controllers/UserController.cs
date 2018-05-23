using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Write.io.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;



namespace Write.io.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        

        public ActionResult Index()
        {
            var loggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                               .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var model = db.Blogs.Where(b => b.User.UserName.Equals(loggedInUser.UserName))
                        .OrderByDescending(b => b.Created).ToList();

            return View(model);
        }


        public ActionResult RemoveBlog(int id)
        {
            Blog obj = db.Blogs.Where(b => b.Id.Equals(id)).SingleOrDefault();

            db.Blogs.Remove(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditBlog(int id)
        {
            Blog obj = db.Blogs.Where(b => b.Id.Equals(id)).SingleOrDefault();

            return View(obj);
        }

        [HttpPost]
        public ActionResult EditBlog(Blog blog)
        {
            var rows = db.Blogs.Where(b => b.Id.Equals(blog.Id));

            foreach (Blog row in rows)
            {
                row.Title = blog.Title;
                row.BlogHeaderURL = blog.BlogHeaderURL;
                row.Body = blog.Body;
                row.Template = blog.Template;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}