using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesTestPre.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

        Task<int> Add(T model);

        Task<T> Find(int id);
        Task<int> Edit(T model);
    }
}