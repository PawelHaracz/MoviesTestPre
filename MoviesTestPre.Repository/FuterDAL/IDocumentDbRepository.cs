using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoviesTestPre.Repository.FuterDAL
{
    public interface IDocumentDbRepository<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);
        Task<T> UpdateItemAsync(string id, T item);
        Task<T> CreateItemAsync(T item);
    }
}