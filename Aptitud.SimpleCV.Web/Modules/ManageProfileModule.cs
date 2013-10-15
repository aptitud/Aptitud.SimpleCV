using System;
using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Raven;
using Nancy;
using Nancy.ModelBinding;

namespace Aptitud.SimpleCV.Web.Modules
{
    public class ManageProfileModule : EditorModule
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