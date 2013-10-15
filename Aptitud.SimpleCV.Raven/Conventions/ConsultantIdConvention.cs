using Aptitud.SimpleCV.Model;
using Raven.Client.Document;

namespace Aptitud.SimpleCV.Raven.Conventions
{
    public class ConsultantIdConvention : IConvention
    {
        public void Register(DocumentConvention convention)
        {
            convention.RegisterIdConvention<Consultant>((s, commands, model) => model.EmailAddress);
        }
    }
}