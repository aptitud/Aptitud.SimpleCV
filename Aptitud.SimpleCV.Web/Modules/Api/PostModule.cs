using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Web.Modules;

namespace Aptitud.SimpleCV.Web {
    public class PostModule : RavenModule {

        public PostModule(ISessionProvider sessionProvider)
            : base(sessionProvider, "/api") {
        }
    }
}