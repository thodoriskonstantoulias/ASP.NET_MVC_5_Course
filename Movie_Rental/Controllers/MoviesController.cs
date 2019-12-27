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
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Id = 1 ,Name = "Seven"},
                new Movie{Id = 2 ,Name = "Die Hard"},
                new Movie{Id = 3 ,Name = "Fast and the Furious"}
            };
        }
    }
}