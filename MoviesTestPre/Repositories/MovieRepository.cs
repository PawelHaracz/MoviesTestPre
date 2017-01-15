using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using MoviesTestPre.DAL;
using MoviesTestPre.Repositories.Interfaces;

namespace MoviesTestPre.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> Get(Expression<Func<Movie, bool>> predicate)
        {
            return await _dbContext.Movies.Where(predicate).ToListAsync();
        }

        public async Task<int> Add(Movie model)
        {
            var movie = _dbContext.Movies.Add(model);
            await _dbContext.SaveChangesAsync();

            return movie.Id;
        }
    }
}