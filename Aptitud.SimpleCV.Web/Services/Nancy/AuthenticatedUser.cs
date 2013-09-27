using System.Collections.Generic;
using Aptitud.SimpleCV.Web.Models;
using Nancy.Security;

namespace Aptitud.SimpleCV.Web.Services.Nancy
{
    public class AuthenticatedUser : IUserIdentity
    {
        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; private set; }

        public static AuthenticatedUser Create(UserLogin login, IEnumerable<string> claims)
        {
            return new AuthenticatedUser
                {
                    UserName = login.Email,
                    Claims = claims,
                };
        }
    }
}