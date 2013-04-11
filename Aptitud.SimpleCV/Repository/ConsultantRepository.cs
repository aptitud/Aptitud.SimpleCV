using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aptitud.SimpleCV.Repository {
	public class ConsultantRepository : IConsultantRepository {

		private readonly Raven.Client.IDocumentStore _store;

		public ConsultantRepository(Raven.Client.IDocumentStore store) {
			_store = store;
		}

		public List<string> GetIds() {
			var consultatIds = new List<string>();

			using (var session = _store.OpenSession()) {
				consultatIds = session.Query<Model.Consultant>().Select(p => p.Id).ToList();
			}
			return consultatIds;
		}

		public Model.Consultant Get(string Id) {
			Model.Consultant consultant = null;

			using (var session = _store.OpenSession()) {
				var consultants = session.Load<Model.Consultant>(new[] { Id });

				if (consultants.Length > 0) {
					consultant = consultants[0];
				}
			}
			return consultant;
		}

		public Model.Consultant Save(string Id, Model.Consultant consultant) {
				using (var session = _store.OpenSession()) {
					session.Store(consultant, Id);
					session.SaveChanges();
				}
			return consultant;
		}

	}
}