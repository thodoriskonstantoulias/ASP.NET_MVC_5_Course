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

        public ActionResult New()
        {
            var genres = _context.MovieGenres.ToList();
            var viewModel = new NewMovieViewModel { MovieGenres = genres };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie) { MovieGenres = _context.MovieGenres.ToList() };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return HttpNotFound();

            var viewModel = new NewMovieViewModel(movie)
            {                
                MovieGenres = _context.MovieGenres.ToList()            
            };

            return View("MovieForm", viewModel);
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