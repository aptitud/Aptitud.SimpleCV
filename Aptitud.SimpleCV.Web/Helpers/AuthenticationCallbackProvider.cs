using System;
using System.Collections.Generic;
using Aptitud.SimpleCV.Web.Services;
using Nancy;
using Nancy.SimpleAuthentication;
using Nancy.Security;

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
                var loginKey = string.Format("{0}_{1}", model.AuthenticatedClient.ProviderName,
                                             model.AuthenticatedClient.UserInformation.Id);
                
                var login = session.Load<UserLogin>(loginKey);

                if(login == null)
                {
                    login = new UserLogin
                        {
                            Id = loginKey,
                            Name = model.AuthenticatedClient.UserInformation.Name,
                            ImageUrl = model.AuthenticatedClient.UserInformation.Picture,
                            Email = model.AuthenticatedClient.UserInformation.Email,
                            Created = DateTime.UtcNow,
                        };
                    session.Store(login);
                }

                login.LoginAt(DateTime.UtcNow);
                session.SaveChanges();

                
                if (login.IsAuthorized())
                    return nancyModule.Response.AsRedirect("/");
                else
                    return nancyModule.Response.AsRedirect("/");

                
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

    public class UserLogin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }

        public List<DateTime> LoggedInAt { get; set; }

        public UserLogin()
        {
            LoggedInAt = new List<DateTime>();
        }

        public void LoginAt(DateTime timestamp)
        {
            LoggedInAt.Add(timestamp);
        }

        public bool IsAuthorized()
        {
            return Email.EndsWith("@aptitud.se", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}