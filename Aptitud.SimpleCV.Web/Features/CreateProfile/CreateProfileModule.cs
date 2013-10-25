using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Web.Modules;
using Nancy;
using Nancy.ModelBinding;

namespace Aptitud.SimpleCV.Web.Features.CreateProfile
{
    public class CreateProfileModule : RavenModule
    {
        public CreateProfileModule(ISessionProvider sessionProvider)
            : base(sessionProvider, "/api/commands")
        {
            Post["/createprofile"] = parameters =>
                {
                    var command = this.Bind<CreateProfileCommand>();

                    var consultant = new Consultant
                    {
                        EmailAddress = command.EmailAddress,
                        Name = command.Name,
                    };

                    RavenSession.Store(consultant);

                    var response = Negotiate
                        .WithStatusCode(HttpStatusCode.Created)
                        .WithContentType("application/json")
                        .WithView("index.sshtml")
                        .WithHeader("location", string.Format("/api/profile/{0}", consultant.Id))
                        .WithModel(new { Message = "Success", Profile = consultant });

                    return response;
                };

            Post["/createprofilefromauthentication"] = parameters =>
                {
                    var command = this.Bind<CreateProfileFromAuthenticationCommand>();

                    var consultant = new Consultant
                        {
                            EmailAddress = command.Email,
                            Name = command.Name,
                        };

                    RavenSession.Store(consultant);

                    var response = Negotiate
                        .WithStatusCode(HttpStatusCode.Created)
                        .WithContentType("application/json")
                        .WithView("index.sshtml")
                        .WithHeader("location", string.Format("/profile/{0}", consultant.Id))
                        .WithModel(new {Message = "Success"});

                    return response;
                };
        }
    }
}