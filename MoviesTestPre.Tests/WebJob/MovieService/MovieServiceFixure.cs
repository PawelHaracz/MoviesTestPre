using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FakeItEasy;
using MoviesTestPre.Repository.DAL;
using MoviesTestPre.Repository.Repositories;
using MoviesTestPre.Repository.Repositories.Interfaces;
using MoviesTestPre.SetMovies.Converters;
using MoviesTestPre.SetMovies.Interfaces;

namespace MoviesTestPre.Tests.WebJob.MovieService
{
    public class MovieServiceFixure
    {
        public readonly IMovieService Service;

        public MovieServiceFixure()
        {
            var converter = new MovieNowPlayingConverter();
            var repository = CreateRepository();

            Service = new SetMovies.MovieService(converter, repository, "https://api.themoviedb.org/3/movie/", "05e64ca9b0e040334b739e85999d7c48");
        }

        private IRepository<Movie> CreateRepository()
        {
            var repository = A.Fake<IRepository<Movie>>();
            var data = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Test 1"
                },

                new Movie
                {
                    Id = 2,
                    Name = "Test 2"
                },
            };

            A.CallTo(() => repository.Get(A<Expression<Func<Movie, bool>>>._))
                .ReturnsLazily((Expression<Func<Movie, bool>> fun) => data);
            A.CallTo(() => repository.Add(A<Movie>._))
                .ReturnsLazily((Movie m) =>
                {
                    data.Add(m);
                    return m.Id;
                });

            return repository;
        }
    }
}
