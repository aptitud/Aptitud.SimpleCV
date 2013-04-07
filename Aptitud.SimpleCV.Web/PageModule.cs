using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace Aptitud.SimpleCV.Web {
	public class PageModule : Nancy.NancyModule {


	private readonly Repository.ConsultantRepository _consultantRepository = new Repository.ConsultantRepository();

		public PageModule() {
			Get["/"] = _ => "Hello Simple CV";

			Get["/Preview/{Id}"] = parameters => {
			 var consultant = _consultantRepository.Get(parameters.Id);
			 
			 return View["View/Preview", consultant];
			} ;

			Get["/Edit/{Id}"] = parameters => {
				var consultant = _consultantRepository.Get(parameters.Id);

				if (consultant == null) {
					consultant = new Model.Consultant{
						EmailAddress = parameters.Id
					};
				}

				return View["View/Consultant/Edit", consultant];
			};

			Post["/SaveConsultantInfo"] = parameters => {
				var form = this.Bind<Model.Consultant>();

				var consultant = new Model.Consultant {
					FirstName = form.FirstName,
					LastName = form.LastName,
					Title = form.Title,
					EmailAddress = form.EmailAddress,
					Summary = form.Summary
				};
				 
				consultant = _consultantRepository.Save(form.EmailAddress, consultant);

				return new RedirectResponse("/Edit/" + form.EmailAddress);
			};

		}
	}
}