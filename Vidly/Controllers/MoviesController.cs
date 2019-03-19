using System;
using System.Web.Mvc;
using System.Collections.Generic;
using Vidly.Models;
using Vidly.ViewModels;

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
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
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

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}