using Raven.Client;

namespace Aptitud.SimpleCV.Web.Services
{
    public interface INeedRavenSession
    {
        IDocumentSession RavenSession { set; }
    }
}
