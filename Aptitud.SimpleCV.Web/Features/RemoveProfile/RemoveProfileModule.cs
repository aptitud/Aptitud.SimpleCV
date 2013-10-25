using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Web.Modules;
using Nancy;
using Nancy.ModelBinding;

namespace Aptitud.SimpleCV.Web.Features.CreateProfile {
    public class RemoveProfileModule : RavenModule {
        public RemoveProfileModule(ISessionProvider sessionProvider)
            : base(sessionProvider, "/api/commands") {

            Delete["/removeprofile/{id}"] = parameters => {
                string id = parameters.id;

                var consultant = RavenSession.Load<Consultant>(id);

                RavenSession.Delete(consultant);

                var response = Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithContentType("application/json")
                    .WithView("index.sshtml")
                    .WithModel(new { Message = "Success" });

                return response;
            };
        }
    }
}