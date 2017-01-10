using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace MoviesTestPre.Repository
{
    public interface IDocumentDbRepository<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);
        Task<T> UpdateItemAsync(string id, T item);
        Task<T> CreateItemAsync(T item);
    }
}