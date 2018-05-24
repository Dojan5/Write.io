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

        //Views individual posts
        [Route("b/{Nickname}/{BlogTitle}/CreatePost")]
        public ActionResult CreatePost(string Nickname, string BlogTitle)
        {
            string UserID = User.Identity.GetUserId();
            return View();
        }

        [Route("b/{Nickname}/{BlogTitle}/{PostID}-{PostTitle}")]
        public ActionResult ViewPost(string Nickname, string BlogTitle, int PostID, string PostTitle)
        {
            BlogPostViewModel model = new BlogPostViewModel();
            model.Populate(Nickname, BlogTitle, PostID, PostTitle);
            return PartialView("ViewPost", model);
        }
    }
}