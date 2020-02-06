using _036_MoviesMvcWissen.Contexts;
using _036_MoviesMvcWissen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Controllers
{
    public class DirectorsController : Controller
    {
        MoviesContext db = new MoviesContext();
        // GET: Directors
        public ViewResult Index()
        {
            var model = db.Directors.ToList();
            return View(model);
        }
    }
}