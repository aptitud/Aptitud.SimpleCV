using Aptitud.SimpleCV.Web.Services;

using Nancy.Security;

namespace Aptitud.SimpleCV.Web.Modules
{
    public abstract class EditorModule : RavenModule
    {
        protected EditorModule(ISessionProvider sessionProvider, string modulePath) : base(sessionProvider, modulePath)
        {
            this.RequiresAuthentication();
            this.RequiresClaims(new[] {ClaimsConstants.Editor});
        }
    }
}