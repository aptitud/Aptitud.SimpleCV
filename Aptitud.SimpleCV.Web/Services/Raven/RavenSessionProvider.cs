using System;
using System.Configuration;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace Aptitud.SimpleCV.Web.Services.Raven
{
    public class RavenSessionProvider : ISessionProvider
    {
        protected static Lazy<IDocumentStore> Documentstore = new Lazy<IDocumentStore>(() =>
            {
                var store = new EmbeddableDocumentStore
                    {
                        DataDirectory = @"App_Data\Raven",
                    };
                
                if (ConfigurationManager.ConnectionStrings["RavenHQ"] != null)
                {
                    store.ConnectionStringName = "RavenHQ";
                }

                store.Initialize();

                IndexCreation.CreateIndexes(typeof (RavenSessionProvider).Assembly, store);

                return store;
            });

        public IDocumentSession GetSession()
        {
            var session = Documentstore.Value.OpenSession();
            return session;
        }
    }
}