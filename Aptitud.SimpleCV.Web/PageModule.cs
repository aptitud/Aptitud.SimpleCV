using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitud.SimpleCV.Web {
	public class PageModule : Nancy.NancyModule {

		public PageModule() {
			Get["/"] = _ => "Hello Stalker";
		}
	}
}