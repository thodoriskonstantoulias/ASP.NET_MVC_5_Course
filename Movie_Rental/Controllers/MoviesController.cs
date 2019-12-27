using Movie_Rental.Models;
using Movie_Rental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Movie_Rental.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.MovieGenre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).FirstOrDefault(m => m.Id == id);

            if (movie == null) return HttpNotFound();

            return View(movie);
        }

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie{Id = 1 ,Name = "Seven"},
        //        new Movie{Id = 2 ,Name = "Die Hard"},
        //        new Movie{Id = 3 ,Name = "Fast and the Furious"}
        //    };
        //}
    }
}