using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitud.SimpleCV.Web {
	public class PageModule : Nancy.NancyModule {


	private readonly Repository.ConsultantRepository _consultantRepository = new Repository.ConsultantRepository();

		public PageModule() {
			Get["/"] = _ => "Hello Stalker";

			Get["/{Id}"] = parameters => {
			 var consultant = _consultantRepository.GetById(parameters.Id);
			 
			 return View["View/Preview", consultant];
			} ;
		}
	}
}