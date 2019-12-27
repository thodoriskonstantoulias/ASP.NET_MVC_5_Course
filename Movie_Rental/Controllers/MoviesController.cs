using Movie_Rental.Models;
using Movie_Rental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Rental.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Seven" };
            var customers = new List<Customer>
            {
                new Customer{Id = 1 , Name = "Ted"},
                new Customer{Id = 2 , Name = "Kostas"},
                new Customer{Id = 3 , Name = "Maria"}
            };
            var randomViewModel = new RandomMovieViewModel { Movie = movie, Customers = customers };

            return View(randomViewModel);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}