using Nancy;
using Raven.Client;
using Raven.Client.Document;
using System.Collections.Generic;

using Nancy.Diagnostics;
using Nancy.Security;
using Nancy.Session;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Aptitud.SimpleCV.Web {
	public class Bootstrap : DefaultNancyBootstrapper {
		
		private IDocumentStore CreateDocumentStore() {
			var documentStore = new DocumentStore { ConnectionStringName = "RavenHQ" };
			documentStore.Initialize();

			return documentStore;
		}

		protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container) {
			var documentStore = CreateDocumentStore();
			container.Register(documentStore);
			container.Register<Repository.IConsultantRepository>(new Repository.ConsultantRepository(documentStore));
		}

		protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines) {
			base.ApplicationStartup(container, pipelines);

			StaticConfiguration.EnableRequestTracing = true;
			StaticConfiguration.DisableErrorTraces = false;
		}

		protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions) {
			base.ConfigureConventions(nancyConventions);

			nancyConventions.StaticContentsConventions.Add(
					Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/Content")
			);
		}
		//public class MyRazorConfiguration : IRazorConfiguration {
		//	public bool AutoIncludeModelNamespace {
		//		get {
		//			return false;
		//		}
		//	}

		//	public IEnumerable<string> GetAssemblyNames() {
		//		return new string[] { };
		//	}

		//	public IEnumerable<string> GetDefaultNamespaces() {
		//		return new string[] { };
		//	}
		//}
	}
}