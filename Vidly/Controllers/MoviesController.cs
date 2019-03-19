using System;
using System.Data.SqlTypes;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //GET: Movies
        //public ViewResult Index()
        //{
        //    return View();
        //}

        public ViewResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            return View(movie);
        }

        public ActionResult Edit(int movieId)
        {
            return Content("Id =" + movieId);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }

        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}