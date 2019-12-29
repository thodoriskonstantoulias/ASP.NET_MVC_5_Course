using Movie_Rental.Dtos;
using Movie_Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie_Rental.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //No need for defensive programming - This is not a public API
            //if (newRental.MoviesIds.Count == 0) return BadRequest("No movie ids have been given");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            //if (customer == null) return BadRequest("Customer id is not valid");

            var movies = _context.Movies.Where(m => newRental.MoviesIds.Contains(m.Id)).ToList(); 
            //if (movies.Count != newRental.MoviesIds.Count) return BadRequest("One or more movie ids are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0) return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
