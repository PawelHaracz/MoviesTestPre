using System;
using System.IdentityModel.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using MoviesTestPre.Infrastructures;
using MoviesTestPre.Repository.DAL;
using Owin;

namespace MoviesTestPre
{
    public partial class Startup
    {
      
        
        //private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public void ConfigureAuth(IAppBuilder app)
        {
            
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseKentorOwinCookieSaver();
            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = AppSettingKey.ClientId,
                    Authority = AppSettingKey.Authority,
                    TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                    {         
                        ValidateIssuer = false,
                        RoleClaimType = "roles"
                    },
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        SecurityTokenValidated = (context) => Task.FromResult(0),
                        AuthorizationCodeReceived = (context) =>
                        {
                            var code = context.Code;

                            var credential = new ClientCredential(AppSettingKey.ClientId, AppSettingKey.AppKey);
                            var tenantId = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
                            var signedInUserId = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;

                            var authContext = new AuthenticationContext(AppSettingKey.AadInstance + tenantId, new AdalTokenCache(signedInUserId));
                            var result = authContext.AcquireTokenByAuthorizationCode(
                                code, new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, AppSettingKey.GraphResourceId);

                            return Task.FromResult(0);
                        },
                        AuthenticationFailed = (context) =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/Error/ShowError?signIn=true&errorMessage=" + context.Exception.Message);
                            return Task.FromResult(0);
                        }
                    }
                });

        }
    }
}
