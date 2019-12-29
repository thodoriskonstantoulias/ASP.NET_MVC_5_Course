using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_Rental.Dtos
{
    public class NewRentalDto
    {
        public int customerId { get; set; }
        public List<int> moviesIds { get; set; }
    }
}