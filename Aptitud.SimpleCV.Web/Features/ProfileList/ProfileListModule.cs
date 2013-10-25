using System.Linq;
using Aptitud.SimpleCV.Raven;
using Nancy;

namespace Aptitud.SimpleCV.Web.Features.ProfileList
{
    public class ProfileListModule : VisitorModule
    {
        public ProfileListModule(ISessionProvider sessionProvider) : base(sessionProvider, "/api/profiles")
        {
            Get["/"] = parameters => Response.AsJson(RavenSession.Query<ProfileListViewModel>().ToList());
        }
    }
}