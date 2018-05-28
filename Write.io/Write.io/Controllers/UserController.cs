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
            var user = User.Identity.GetUserId();

            var model = db.Blogs.Where(b => b.UserId.Equals(user)).ToList();
            

            return View(model);
        }


        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(AddBlogViewModel obj)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog();
                
                blog.UserId = User.Identity.GetUserId(); ;
                blog.Created = DateTime.Now;
                blog.Title = obj.title;
                blog.BlogHeaderURL = obj.url;
                blog.Body = obj.body;
                blog.Template = obj.template;

                db.Blogs.Add(blog);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
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
            var blog = db.Blogs.Where(b => b.Id.Equals(obj.Id)).FirstOrDefault();

            if (ModelState.IsValid)
            {
                blog.Title = obj.Title;
                blog.BlogHeaderURL = obj.BlogHeaderURL;
                blog.Body = obj.Body;
                blog.Template = obj.Template;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}