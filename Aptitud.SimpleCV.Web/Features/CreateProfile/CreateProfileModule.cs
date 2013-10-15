﻿using Aptitud.SimpleCV.Model;
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
                        FirstName = command.FirstName,
                        LastName = command.LastName,
                    };

                    RavenSession.Store(consultant);

                    var response = Negotiate
                        .WithStatusCode(HttpStatusCode.Created)
                        .WithContentType("application/json")
                        .WithView("index.sshtml")
                        .WithHeader("location", string.Format("/profile/{0}", consultant.Id))
                        .WithModel(new { Message = "Success" });

                    return response;
                };

            Post["/createprofilefromauthentication"] = parameters =>
                {
                    var command = this.Bind<CreateProfileFromAuthenticationCommand>();

                    var consultant = new Consultant
                        {
                            EmailAddress = command.Email,
                            FullName = command.Name,
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

    public class CreateProfileCommand
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}