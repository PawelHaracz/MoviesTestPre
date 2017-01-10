using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using MoviesTestPre.Repository.Model;

namespace MoviesTestPre.Repository
{
    public class DocumentDbRepository<T> :  DocumentRepositoryBase, IDocumentDbRepository<T> where T : class
    {
        public DocumentDbRepository(IDocumentClient client, DatabaseConfig config):
            base(client, config)
        {
            
        }

        public async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            // ReSharper disable once GenericEnumeratorNotDisposed
            var query = Client.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                .Where(predicate).GetEnumerator();


            var results = new List<T>();
            while (query.MoveNext())
            {
                results.Add(query.Current);
            }
            //!!!NOT PASS A Unit test :( InvalidCastException, I think that it is fault a fakeiteasy
            //var query = client.CreateDocumentQuery<T>(
            //        UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId))
            //    .Where(predicate)
            //   .AsDocumentQuery();

            // List<T> results = new List<T>();
            //while (query.HasMoreResults)
            //{
            //    results.AddRange(await query.ExecuteNextAsync<T>());
            //}

            return results;
        }

        public async Task<T> CreateItemAsync(T item)
        {
            return (T)(dynamic)await Client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }
        public async Task<T> UpdateItemAsync(string id, T item)
        {
            return (T)(dynamic)await Client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

    }
}
