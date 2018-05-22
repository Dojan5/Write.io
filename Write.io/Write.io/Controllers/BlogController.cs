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
    }
}