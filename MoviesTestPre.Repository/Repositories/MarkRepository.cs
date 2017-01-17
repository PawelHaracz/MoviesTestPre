using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MoviesTestPre.Repository.DAL;
using MoviesTestPre.Repository.Repositories.Interfaces;

namespace MoviesTestPre.Repository.Repositories
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
            return await _dbContext.Marks.Where(predicate).ToListAsync();
        }

        public async Task<int> Add(Mark model)
        {
          var mark =   _dbContext.Marks.Add(model);
          await  _dbContext.SaveChangesAsync();  
          return mark.Id;
        }

        public async Task<Mark> Find(int id)
        {
            var mark = await _dbContext.Marks.FindAsync(id);

            return mark;
        }

        public async Task<int> Edit(Mark model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }
    }
}