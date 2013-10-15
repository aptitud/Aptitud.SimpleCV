using System;
using Aptitud.SimpleCV.Raven;
using Nancy;
using Raven.Client;

namespace Aptitud.SimpleCV.Web.Modules
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
                            if(RavenSession.Advanced.HasChanges)
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