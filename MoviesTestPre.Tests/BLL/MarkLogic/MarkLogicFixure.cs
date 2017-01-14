using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.Common.Mappers;
using MoviesTestPre.DAL;
using MoviesTestPre.Repositories.Interfaces;

namespace MoviesTestPre.Tests.BLL.MarkLogic
{
    public class MarkLogicFixure 
    {
        public readonly IMarkLogic Logic;

        public MarkLogicFixure()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MarkDalToMovieDtoProfile()));
            var mapper = config.CreateMapper();
            var repository = MockRepository();
            Logic = new MoviesTestPre.BLL.MarkLogic(mapper, repository);
        }

        private IRepository<Mark> MockRepository()
        {
            var repository = A.Fake<IRepository<Mark>>();

            var marks = new List<Mark>
            {
                new Mark {Comment = "test 1",Id=1, Movie = new Movie {Id =2 , Name = "Firs Movie"}, MovieId = 2, UserName = "Paweł Haracz"},
                new Mark {Comment = "test 2",Id=1, Movie = new Movie {Id =2 , Name = "Firs Movie"}, MovieId = 2, UserName = "Jakub Testowy"},
                new Mark {Comment = "test 3",Id=1, Movie = new Movie {Id =3 , Name = "Second Movie"}, MovieId = 3, UserName = "Paweł Haracz"}
            };

          
            A.CallTo(() => repository.Get(A<Expression<Func<Mark, bool>>>._))
                .ReturnsLazily((Expression<Func<Mark, bool>> f) =>
                {
                    var enumerable = marks.Where(f.Compile());
                    return enumerable;
                });

            return repository;
        }
    }
}
