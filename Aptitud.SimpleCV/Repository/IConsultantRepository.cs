
namespace Aptitud.SimpleCV.Repository {
	public interface IConsultantRepository {
		Model.Consultant Get(string Id);
		Model.Consultant Save(string Id, Model.Consultant consultant);
	}
}