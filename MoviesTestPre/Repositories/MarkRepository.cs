using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MoviesTestPre.DAL;
using MoviesTestPre.Repositories.Interfaces;

namespace MoviesTestPre.Repositories
{
    public class MarkRepository : IRepository<Mark>
    {
        private readonly ApplicationDbContext _dbContext;
        public MarkRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Mark>> Get(Expression<Func<Mark, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}