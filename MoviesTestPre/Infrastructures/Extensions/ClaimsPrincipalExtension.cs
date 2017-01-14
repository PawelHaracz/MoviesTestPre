using System.Security.Claims;

namespace MoviesTestPre.Infrastructures.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static bool IsClaimsRole(this ClaimsPrincipal user, string roleName)
        {
            return user.HasClaim("roles", roleName);
        }
    }
}