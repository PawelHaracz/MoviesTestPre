﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.DAL;
using MoviesTestPre.Infrastructures.Mappers;
using MoviesTestPre.Repositories.Interfaces;

namespace MoviesTestPre.Tests.BLL.MovieLogic
{
    public class MovieLogicFixure
    {
        public readonly IMovieLogic Logic;

        public MovieLogicFixure()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MovieDalToDictionaryProfile()));
            var mapper = config.CreateMapper();
            var repository = MockRepository();
            Logic = new MoviesTestPre.BLL.MovieLogic(mapper,repository);
        }

        private IRepository<Movie> MockRepository()
        {
            var repository = A.Fake<IRepository<Movie>>();

            return repository;
        }
    }
}
