using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MoviesTestPre.BLL.Interfaces;
using MoviesTestPre.Common.Extensions;
using MoviesTestPre.DAL;

namespace MoviesTestPre.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMarkLogic _logic;
        public MoviesController(IMarkLogic logic)
        {
            _logic = logic;
        }

        // GET: Movies
        public async Task<ActionResult >Index()
        {
            var user = HttpContext.GetOwinContext().Authentication.User;

            var model = await _logic.GetAll(user.Identity.Name, user.IsClaimsRole(Roles.Admin));

            return View(model);
        }
    }
}