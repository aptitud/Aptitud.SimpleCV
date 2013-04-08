using Nancy;
using Raven.Client;
using Raven.Client.Document;

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
	}
}