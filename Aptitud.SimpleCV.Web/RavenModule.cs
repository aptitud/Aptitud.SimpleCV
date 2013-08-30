using System;
using Aptitud.SimpleCV.Web.Services;
using Nancy;
using Raven.Client;

namespace Aptitud.SimpleCV.Web
{
    public abstract class RavenModule : NancyModule
    {
        protected IDocumentSession RavenSession;

        protected RavenModule(ISessionProvider sessionProvider, string modulePath):base(modulePath)
        {
            Before += ctx =>
                {
                    RavenSession = sessionProvider.GetSession();
                    return null;
                };

            After += ctx =>
                {
                    if (RavenSession != null)
                    {
                        try
                        {
                            RavenSession.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        finally
                        {
                            RavenSession.Dispose();
                        }
                    }
                };
        }
    }
}