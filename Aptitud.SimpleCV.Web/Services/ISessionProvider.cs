using Raven.Client;

namespace Aptitud.SimpleCV.Web.Services
{
    public interface ISessionProvider
    {
        IDocumentSession GetSession();
    }
}
