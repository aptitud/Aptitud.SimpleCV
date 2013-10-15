using System;
using System.Linq;
using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Web.Models;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.SimpleAuthentication;

namespace Aptitud.SimpleCV.Web.Helpers
{
    public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        private readonly ISessionProvider _sessionProvider;

        public AuthenticationCallbackProvider(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public dynamic Process(NancyModule nancyModule, AuthenticateCallbackData model)
        {
            using (var session = _sessionProvider.GetSession())
            {
                var login = session.Query<UserLogin>().
                                   FirstOrDefault(x => x.Providers.Any(y => y.IdentityKey == model.AuthenticatedClient.UserInformation.Id));

                if(login == null)
                {
                    login = new UserLogin
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = model.AuthenticatedClient.UserInformation.Name,
                            ImageUrl = model.AuthenticatedClient.UserInformation.Picture,
                            Email = model.AuthenticatedClient.UserInformation.Email,
                            Created = DateTime.UtcNow,
                        };
                    session.Store(login);
                }

                if (login.ContainsProvider(model.AuthenticatedClient.ProviderName) == false)
                {
                    login.Providers.Add(new UserLogin.LoginProvider
                        {
                            Name = model.AuthenticatedClient.ProviderName,
                            IdentityKey = model.AuthenticatedClient.UserInformation.Id,
                        });
                }
                    
                login.LoginAt(DateTime.UtcNow);
                session.SaveChanges();

                return nancyModule.LoginAndRedirect(Guid.Parse(login.Id));
            }
        }

        public dynamic OnRedirectToAuthenticationProviderError(NancyModule nancyModule, string errorMessage)
        {
            var model = new IndexViewModel
            {
                ErrorMessage = errorMessage
            };

            return nancyModule.View["index", model];
        }
    }
}