using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Web.Modules;
using Nancy.Security;

namespace Aptitud.SimpleCV.Web
{
    public abstract class VisitorModule : RavenModule
    {
        protected VisitorModule(ISessionProvider sessionProvider, string modulePath) : base(sessionProvider, modulePath)
        {
            this.RequiresAuthentication();
            this.RequiresClaims(new[] { ClaimsConstants.Visitor });
        }
    }
}