using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using MoviesTestPre.Repository;
using MoviesTestPre.Repository.FuterDAL;
using MoviesTestPre.Repository.FuterDAL.Model;

namespace MoviesTestPre.Tests.Repository.DocumentDbRepository
{
    public class DocumentDbRepositoryFixure
    {
        public readonly IDocumentDbRepository<ExampleModel> Fixure;

        public DocumentDbRepositoryFixure()
        {
            var config = new DatabaseConfig()
            {
                CollectionId = "test",
                DataBaseId = "test"
            };
            
            var client = MockDocumentClient();


            Fixure = new DocumentDbRepository<ExampleModel>(client,config);
        }

        private IDocumentClient MockDocumentClient()
        {
            IDocumentClient client = A.Fake<IDocumentClient>();
            IOrderedQueryable<ExampleModel> returnValueCollection = new List<ExampleModel>()
                {
                    new ExampleModel() {Name = "A", Number = 25},
                    new ExampleModel() {Name = "@#d", Number = -8587}
                }
                .AsQueryable()
                .OrderBy(p => 0);


            A.CallTo(() => client.CreateDocumentQuery<ExampleModel>(A<Uri>._, A<FeedOptions>.Ignored))
                .Returns(returnValueCollection);

            A.CallTo(() => client.CreateDocumentAsync(A<Uri>._, A<ExampleModel>._ ,A<RequestOptions>.Ignored, A<bool>.Ignored))
                .Returns(new ResourceResponse<Document>(new Document()));

            A.CallTo(() => client.ReplaceDocumentAsync(A<Uri>._, A<ExampleModel>._, A<RequestOptions>.Ignored))
              .Returns(new ResourceResponse<Document>(new Document()));

            return client;
        }
    }

    public class ExampleModel
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("number")]
        public int Number { get; set; }
    }
}
