using System.Linq;
using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Web.Modules;
using Nancy;

namespace Aptitud.SimpleCV.Web {
    public class GetModule : RavenModule {

        public GetModule(ISessionProvider sessionProvider)
            : base(sessionProvider, "/api") {
            Get["/consultants"] = _ => {
                var list = RavenSession.Query<Consultant>().ToList();

                return Response.AsJson(list);
            };

            Get["/profile/{id}"] = parameters => {
                string id = parameters.id;

                var consultant = RavenSession.Load<Consultant>(id);

                return Response.AsJson(consultant);
            };

        }
    }
}