using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Raven.Conventions;
using Aptitud.SimpleCV.Raven.Impl;
using Aptitud.SimpleCV.Web.Helpers;
using Nancy;
using Nancy.SimpleAuthentication;
using Nancy.Testing;
using Raven.Client;
using Raven.Client.Embedded;

namespace Specs
{
    public class BrowserProvider
    {
        private static EmbeddableDocumentStore _store;

        public static Browser GetBrowser()
        {
            var bootstrapper = new ConfigurableBootstrapper(configurator =>
                {
                    configurator.Dependency(CreateInMemorySesionProvider());
                    configurator.Dependency<IAuthenticationCallbackProvider>(new MockedAuthenticationCallBackProvider());
                    configurator.AllDiscoveredModules();
                    configurator.EnableAutoRegistration();
                });

            return new Browser(bootstrapper);
        }

        public static IDocumentSession GetSession()
        {
            CreateInMemoryDocumentStore();

            return _store.OpenSession();
        }

        public static IDocumentStore CreateInMemoryDocumentStore(bool forceNew = false)
        {
            if (forceNew || _store == null)
            {
                _store = new EmbeddableDocumentStore
                    {
                        RunInMemory = true,
                    };

                _store.Initialize();

                ConventionsLoader.Register(_store.Conventions, typeof (ConsultantIdConvention).Assembly);
            }

            return _store;
        }

        private static ISessionProvider CreateInMemorySesionProvider()
        {

            return new InMemorySessionProvider(_store);
        }

        public class InMemorySessionProvider : ISessionProvider
        {
            private readonly IDocumentStore _documentStore;

            public InMemorySessionProvider(IDocumentStore documentStore)
            {
                _documentStore = documentStore;
            }

            public IDocumentSession GetSession()
            {
                return _documentStore.OpenSession();
            }
        }
    }

    public class MockedAuthenticationCallBackProvider : IAuthenticationCallbackProvider
    {
        public dynamic Process(NancyModule nancyModule, AuthenticateCallbackData model)
        {
            throw new System.NotImplementedException();
        }

        public dynamic OnRedirectToAuthenticationProviderError(NancyModule nancyModule, string errorMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}
