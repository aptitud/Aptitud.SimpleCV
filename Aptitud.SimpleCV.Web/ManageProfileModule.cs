using System;
using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Web.Services;
using Nancy;
using Nancy.ModelBinding;

namespace Aptitud.SimpleCV.Web
{
    public class ManageProfileModule : RavenModule
    {
        public ManageProfileModule(ISessionProvider sessionProvider) : base(sessionProvider, "/manage/profile")
        {
            Get["/create"] = parameters => View["view/profile/Create.cshtml", new {CommandId = Guid.NewGuid(), Action = "/manage/profile/create", Method = "POST",}];

            Post["/create"] = parameters =>
                {
                    var consultant = this.Bind<Consultant>();

                    consultant.Id = consultant.EmailAddress;

                    RavenSession.Store(consultant);

                    return Response.AsRedirect("/view/" + consultant.Id);
                };
        }

    }
}