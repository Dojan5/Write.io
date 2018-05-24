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

            var model = db.Blogs.Where(b => b.User.UserName.Equals(loggedInUser.UserName)).ToList();

            return View(model);
        }


        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blog obj)
        {
            var loggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                               .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            obj.User = loggedInUser;

            obj.Created = DateTime.Now;

            //if (ModelState.IsValid)
            //{
            db.Blogs.Add(obj);

            db.SaveChanges();

            return RedirectToAction("Index");
            //}
            //return View(obj);

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
        public ActionResult EditBlog(Blog obj)
        {
            var row = db.Blogs.Where(b => b.Id.Equals(obj.Id)).FirstOrDefault();

            if (ModelState.IsValid)
            {
                row.Title = obj.Title;
                row.BlogHeaderURL = obj.BlogHeaderURL;
                row.Body = obj.Body;
                row.Template = obj.Template;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}