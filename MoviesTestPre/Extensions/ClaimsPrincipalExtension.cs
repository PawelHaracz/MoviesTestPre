using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MoviesTestPre.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static bool IsClaimsRole(this ClaimsPrincipal user, string roleName)
        {
            return user.HasClaim("roles", roleName);
        }
    }
}