using System.Linq;
using Aptitud.SimpleCV.Model;
using Aptitud.SimpleCV.Web.Services;
using Nancy.ModelBinding;
using Nancy.Responses;
using SimpleAuthentication.Core.Tracing;

namespace Aptitud.SimpleCV.Web {
	public class PageModule : RavenModule {
		public PageModule(ISessionProvider sessionProvider):base(sessionProvider, ""){



            //Get["/"] = _ => {
            //    var list = RavenSession.Query<Consultant>().ToList();
            //    return View["View/Consultant/Index", list];
            //};

			Get["/New"] = _ => {
				return "<h1>Not done!</h1>";
			};

			Get["/View/{Id}"] = parameters => {
				var consultant = RavenSession.Load<Consultant>(parameters.Id.ToString());

				return View["View/Consultant/View", consultant];
			};

			Get["/Preview/{Id}"] = parameters => {
				var consultant = RavenSession.Load<Consultant>(parameters.Id.ToString());

				return View["View/Preview", consultant];
			};

			Get["/Edit/{Id}"] = parameters => {
				var consultant = RavenSession.Load<Consultant>(parameters.Id.ToString());

				if (consultant == null) {
					consultant = new Model.Consultant {
						EmailAddress = parameters.Id
					};
				}

				return View["View/Consultant/Edit", consultant];
			};

		    Post["/SaveConsultantInfo"] = parameters =>
		        {
		            string id = Request.Form.Id.ToString();

		            var consultant = RavenSession.Load<Consultant>(id);

		            this.BindTo(consultant, "Id");

		            return new RedirectResponse("/Edit/" + consultant.Id);
		        };
		}
	}
}