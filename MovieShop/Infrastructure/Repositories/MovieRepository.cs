using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public MovieRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Movie> Get30HighestGrossingMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(x => x.Revenue).Take(100).ToList();
            return movies;
        }

    }
}
