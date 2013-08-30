﻿using Nancy.ModelBinding;
using Nancy.Responses;

namespace Aptitud.SimpleCV.Web {
	public class PageModule : Nancy.NancyModule {


		private readonly Repository.IConsultantRepository _consultantRepository;

		public PageModule(Repository.IConsultantRepository consultantRepository) {
			_consultantRepository = consultantRepository;

			Get["/"] = _ => {
				var list = _consultantRepository.GetAll();
				return View["View/Consultant/Index", list];
			};

			Get["/New"] = _ => {
				return "<h1>Not done!</h1>";
			};

			Get["/View/{Id}"] = parameters => {
				var consultant = _consultantRepository.Get(parameters.Id);

				return View["View/Consultant/View", consultant];
			};

			Get["/Preview/{Id}"] = parameters => {
				var consultant = _consultantRepository.Get(parameters.Id);

				return View["View/Preview", consultant];
			};

			Get["/Edit/{Id}"] = parameters => {
				var consultant = _consultantRepository.Get(parameters.Id);

				if (consultant == null) {
					consultant = new Model.Consultant {
						EmailAddress = parameters.Id
					};
				}

				return View["View/Consultant/Edit", consultant];
			};

			Post["/SaveConsultantInfo"] = parameters => {
				var form = this.Bind<Model.Consultant>();

				var consultant = new Model.Consultant {
					Id = form.EmailAddress,
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