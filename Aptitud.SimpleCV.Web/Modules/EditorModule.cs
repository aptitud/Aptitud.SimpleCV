using Aptitud.SimpleCV.Web.Services;

using Nancy.Security;

namespace Aptitud.SimpleCV.Web.Modules
{
    public class EditorModule : RavenModule
    {
        public EditorModule(ISessionProvider sessionProvider) : base(sessionProvider, "/edit")
        {
            this.RequiresAuthentication();
            this.RequiresClaims(new[] {"Editor"});

            Get["/"] = parameters => "Kalle";
        }
    }
}