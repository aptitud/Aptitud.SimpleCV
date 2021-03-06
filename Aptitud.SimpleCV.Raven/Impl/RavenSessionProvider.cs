﻿using System;
using System.Configuration;
using System.Reflection;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace Aptitud.SimpleCV.Raven.Impl
{
    public class RavenSessionProvider : ISessionProvider
    {
        private static Assembly _conventionsAssembly;

        public RavenSessionProvider(Assembly conventionsAssembly)
        {
            _conventionsAssembly = conventionsAssembly;
        }

        protected static Lazy<IDocumentStore> Documentstore = new Lazy<IDocumentStore>(() =>
            {
                var store = new EmbeddableDocumentStore
                    {
                        DataDirectory = @"App_Data\Raven",
                    };
                
                if (ConfigurationManager.ConnectionStrings["RavenHQ"] != null && string.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings["RavenHQ"].ConnectionString) == false)
                {
                    store.ConnectionStringName = "RavenHQ";
                }

                store.Initialize();

                IndexCreation.CreateIndexes(typeof (RavenSessionProvider).Assembly, store);
                ConventionsLoader.Register(store.Conventions, _conventionsAssembly);

                return store;
            });

        public IDocumentSession GetSession()
        {
            var session = Documentstore.Value.OpenSession();
            return session;
        }
    }
}