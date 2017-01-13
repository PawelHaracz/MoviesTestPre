using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MoviesTestPre.Extensions;

namespace MoviesTestPre.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        public MoviesController()
        {
           
        }

        // GET: Movies
        public ActionResult Index()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var str = $"Is Admin: {authenticationManager.User.IsClaimsRole("Admin")}";
            return View(str);
        }
    }
}