
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public class MovieService: IMovieService
    {
        public List<MovieCardResponseModel> GetTop30GrossingMovies()
        {
            var movies = new List<MovieCardResponseModel>()
            {
                new MovieCardResponseModel() { Id = 1, Title = "Inception", PosterUrl = "https://flxt.tmsimg.com/assets/p7825626_p_v10_af.jpg" },
            new MovieCardResponseModel() { Id = 2, Title = "Pulp Fiction", PosterUrl = "https://bloximages.chicago2.vip.townnews.com/bozemandailychronicle.com/content/tncms/assets/v3/editorial/d/2a/d2a8d415-bd28-54dd-89c0-d627d04a56bb/5d38dcdfa51ff.hires.jpg" }

            };
            return movies;
        }
       

    }
}
