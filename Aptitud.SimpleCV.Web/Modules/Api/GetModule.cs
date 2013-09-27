using System.Linq;
using System.Collections.Generic;
using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Web.Modules;
using Aptitud.SimpleCV.Web.Services;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy;

namespace Aptitud.SimpleCV.Web {
    public class GetModule : RavenModule {

        public GetModule(ISessionProvider sessionProvider)
            : base(sessionProvider, "/api") {
            Get["/consultants"] = _ => {
                var list = RavenSession.Query<Consultant>().ToList();

                return Response.AsJson(list);
            };
        }
    }
}