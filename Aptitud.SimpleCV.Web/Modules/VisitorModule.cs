using Aptitud.SimpleCV.Raven;
using Nancy.Security;

namespace Aptitud.SimpleCV.Web.Modules
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