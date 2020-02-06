using _036_MoviesMvcWissen.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Controllers
{
    public class ReviewsController : Controller
    {
        MoviesContext db = new MoviesContext();
        // GET: Reviews
        public ActionResult Index()
        {
            var model = db.Reviews.ToList();
            return View(model);
        }
    }
}