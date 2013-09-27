using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptitud.SimpleCV.Web.Models
{
    public class UserLogin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public IList<LoginProvider> Providers { get; set; }

        public List<DateTime> LoggedInAt { get; set; }

        public UserLogin()
        {
            LoggedInAt = new List<DateTime>();
            Providers = new List<LoginProvider>();
        }

        public void LoginAt(DateTime timestamp)
        {
            LoggedInAt.Add(timestamp);
        }

        public bool IsAuthorized()
        {
            return Email.EndsWith("@aptitud.se", StringComparison.InvariantCultureIgnoreCase);
        }

        public bool ContainsProvider(string providerName)
        {
            return Providers.Any(x => x.Name == providerName);
        }

        public class LoginProvider
        {
            public string Name { get; set; }
            public string IdentityKey { get; set; }
        }
    }
}