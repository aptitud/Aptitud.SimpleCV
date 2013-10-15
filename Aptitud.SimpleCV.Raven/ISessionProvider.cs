using Raven.Client;

namespace Aptitud.SimpleCV.Raven
{
    public interface ISessionProvider
    {
        IDocumentSession GetSession();
    }
}
