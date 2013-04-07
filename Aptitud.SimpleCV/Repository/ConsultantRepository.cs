using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aptitud.SimpleCV.Repository {
	public class ConsultantRepository {

		public Model.Consultant Get(string Id) {

			Model.Consultant consultant = null;

			using (var store = new Raven.Client.Document.DocumentStore { ConnectionStringName = "RavenHQ" }) {
				store.Initialize();


				using (var session = store.OpenSession()) {
					var consultants = session.Load<Model.Consultant>(new[] { Id });

					if (consultants.Length > 0) {
						consultant = consultants[0];
					}
				}
			}
			return consultant;
		}


		public Model.Consultant Save(string Id, Model.Consultant consultant) {
			using (var store = new Raven.Client.Document.DocumentStore { ConnectionStringName = "RavenHQ" }) {
				store.Initialize();

				using (var session = store.OpenSession()) {
					session.Store(consultant, Id);
					session.SaveChanges();
				}
			}
			return consultant;
		}

	}
}