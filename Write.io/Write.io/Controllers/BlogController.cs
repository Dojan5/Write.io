using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Write.io.Models;

namespace Write.io.Controllers
{
    public class BlogController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Blog
        //This uses something called "Attribute Routing" which needs to be enabled in the RouteConfig.cs file
        [Route("b/{Nickname}/{BlogTitle}/")]
        public ActionResult Index(string Nickname, string BlogTitle)
        {
            BlogViewModel model = new BlogViewModel();
            if (model.Populate(Nickname, BlogTitle) == true)
            {
                return View(model);
            }
            else
            {
                throw new HttpException(404, "The blog could not be found.");
            }
        }

        //Overload to support searching
        [Route("b/{Nickname}/{BlogTitle}/S/{Query}")]
        public ActionResult Index(string Nickname, string BlogTitle, string Query)
        {
            BlogViewModel model = new BlogViewModel();
            if (model.Populate(Nickname, BlogTitle, Query) == true)
            {
                return View(model);
            }
            else
            {
                throw new HttpException(404, "The blog could not be found.");
            }
        }

        //Get method for the create a post dialogue
        [Route("b/{Nickname}/{BlogTitle}/CreatePost"), HttpGet]
        public ActionResult CreatePost()
        {
            var model = new Post()
            {
                Title = "",
                Body = ""
            };

            return View(model);
        }
        //Post method
        [Route("b/{Nickname}/{BlogTitle}/CreatePost"), HttpPost]
        public ActionResult CreatePost(Post model, string Nickname, string BlogTitle)
        {
            model.Blog = db.Blogs.Where(b => b.Title == BlogTitle && b.User.Nickname == Nickname).SingleOrDefault();
            //Checks if the logged on user is the owner of the blog
            if (User.Identity.GetUserId() == model.Blog.User.Id)
            {
                ViewBag.Message = Post.CreateOrUpdate(model);
            }
            else
            {
                ViewBag.Message = "You can't create a post on a blog you don't own.";
            }
            
            return View(ViewBag.Message);
        }
        //Views individual posts
        [Route("b/{Nickname}/{BlogTitle}/{PostID}-{PostTitle}")]
        public ActionResult ViewPost(string Nickname, string BlogTitle, int PostID, string PostTitle)
        {
            BlogPostViewModel model = new BlogPostViewModel();
            model.Populate(Nickname, BlogTitle, PostID, PostTitle);
            return PartialView("ViewPost", model);
        }

        [HttpPost]
        public JsonResult PostComment(Comment model)
        {
            if (model != null)
            {
                model.UserId = User.Identity.GetUserId();
                model.created = DateTime.Now;
                db.Comments.Add(model);
                db.SaveChanges();
                return Json("Your comment has been created.");
            }
            else
            {
                return Json("An error has occured. Dispatching codemonkeys.");
            }
        }
    }
}