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
        public ActionResult Index()
        {
            BlogViewModel model = new BlogViewModel();
            model.Populate(1);
            return View(model);
        }
    }
}