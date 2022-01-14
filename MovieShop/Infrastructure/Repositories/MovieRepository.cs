using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public MovieRepository(MovieShopDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task <List<Movie>> Get30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(x => x.Revenue).Take(30).ToListAsync();
            return movies;
        }
        public override async Task<Movie> GetById(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.Trailers)
                .Include(m => m.GenresOfMovie).ThenInclude(m => m.Genre)
                .Include(m=> m.CastsOfMovie).ThenInclude(m=>m.Cast)
                .SingleOrDefaultAsync(m => m.Id == id);
            return movie;
        }


    }
}
