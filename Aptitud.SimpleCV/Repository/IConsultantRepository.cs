using System.Collections.Generic;

namespace Aptitud.SimpleCV.Repository {
	public interface IConsultantRepository {
		List<string> GetIds();
		Model.Consultant Get(string Id);
		List<Model.Consultant> GetAll();
		Model.Consultant Save(string Id, Model.Consultant consultant);
	}
}