using System;
using System.Collections.Generic;
using Aptitud.SimpleCV.Web.Models;
using Aptitud.SimpleCV.Web.Modules;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace Aptitud.SimpleCV.Web.Services.Nancy
{
    public class RavenUserMapper : IUserMapper
    {
        private readonly ISessionProvider _sessionProvider;

        public RavenUserMapper(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            using (var session = _sessionProvider.GetSession())
            {
                var login = session.Load<UserLogin>(identifier.ToString());
                if (login == null)
                    return null;

                var claims = new List<string>(new[] {ClaimsConstants.Visitor});
                if(login.Email.EndsWith("@aptitud.se"))
                    claims.Add(ClaimsConstants.Editor);

                return CvUser.Create(login, claims);
            }
        }
    }

    public class CvUser : IUserIdentity
    {
        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; private set; }

        public static CvUser Create(UserLogin login, IEnumerable<string> claims)
        {
            return new CvUser
                {
                    UserName = login.Email,
                    Claims = claims,
                };
        }
    }
}