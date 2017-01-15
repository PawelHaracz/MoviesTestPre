﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.DAL;
using MoviesTestPre.DTO;
using MoviesTestPre.Infrastructures.Extensions;

namespace MoviesTestPre.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMarkLogic _markLogic;
        private readonly IMovieLogic _moviesLogic;
        public MoviesController(IMarkLogic markLogic, IMovieLogic moviesLogic)
        {
            _markLogic = markLogic;
            _moviesLogic = moviesLogic;
        }
        [HttpGet]
        public async Task<ActionResult >Index()
        {
            var user = HttpContext.GetOwinContext().Authentication.User;

            var model = await _markLogic.GetAll(user.Identity.Name, user.IsClaimsRole(Roles.Admin));

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var movies = await _moviesLogic.GetAllMovies();
            return View(movies);
        }

        [HttpPost]
        public async Task<ActionResult> Create(string comment, int movieId)
        {
            var user = HttpContext.GetOwinContext().Authentication.User;

            var model = new MarkDto()
            {
                Comment = comment,
                MovieId = movieId,
                UserName = user.Identity.Name
            };
            await _markLogic.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var movies = await _moviesLogic.GetAllMovies();
            var mark = await _markLogic.Get(id);

            var model = new Tuple<IDictionary<int,string>,MarkDto>(movies,mark);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, string comment, int movieId)
        {
            var user = HttpContext.GetOwinContext().Authentication.User;

            var model = new MarkDto()
            {
                Id =  id,
                Comment = comment,
                MovieId = movieId,
                UserName = user.Identity.Name
            };
            await _markLogic.Update(model);
            return RedirectToAction("Index");
        }
    }
}