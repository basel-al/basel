using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseResponseModel
    {

        public int UserId { get; set; }
        public int TotalMoviesPurchased;
        public List<MovieCardResponseModel> PurchasedMovies { get; set; }
    }
}
