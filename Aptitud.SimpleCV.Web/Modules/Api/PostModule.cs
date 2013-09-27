using System.Linq;
using System.Collections.Generic;
using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Web.Modules;
using Aptitud.SimpleCV.Web.Services;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy;

namespace Aptitud.SimpleCV.Web {
    public class PostModule : RavenModule {

        public PostModule(ISessionProvider sessionProvider)
            : base(sessionProvider, "/api") {
        }
    }
}