using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Claims;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using MoviesTestPre.Models;

namespace MoviesTestPre
{
    public partial class Startup
    {
        private readonly string _clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private readonly string _appKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
        private readonly string _graphResourceId = "https://graph.windows.net";
        private readonly string _aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private readonly string _authority = $"{ConfigurationManager.AppSettings["ida:AADInstance"]}common";
        
        //private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public void ConfigureAuth(IAppBuilder app)
        {
            
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            app.UseOpenIdConnectAuthentication(
                openIdConnectOptions: new OpenIdConnectAuthenticationOptions
                {
                    ClientId = _clientId,
                    Authority = _authority,
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

                            var credential = new ClientCredential(_clientId, _appKey);
                            var tenantId = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
                            var signedInUserId = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;

                            var authContext = new AuthenticationContext(_aadInstance + tenantId, new ADALTokenCache(signedInUserId));
                            var result = authContext.AcquireTokenByAuthorizationCode(
                                code, new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, _graphResourceId);

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
