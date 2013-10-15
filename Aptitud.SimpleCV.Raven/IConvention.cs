using Raven.Client.Document;

namespace Aptitud.SimpleCV.Raven
{
    public interface IConvention
    {
        void Register(DocumentConvention convention);
    }
}
