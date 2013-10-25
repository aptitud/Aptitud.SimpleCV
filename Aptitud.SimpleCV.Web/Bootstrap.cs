using System;
using System.Collections.Generic;
using System.Reflection;
using Aptitud.SimpleCV.Raven;
using Aptitud.SimpleCV.Raven.Impl;
using Aptitud.SimpleCV.Web.Helpers;
using Aptitud.SimpleCV.Web.Services.Nancy;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.SimpleAuthentication;

namespace Aptitud.SimpleCV.Web
{
    public class Bootstrap : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ISessionProvider>((cContainer, overloads) => new RavenSessionProvider(typeof(IConvention).Assembly));
            container.Register<IAuthenticationCallbackProvider>((cContainer, overloads) => new AuthenticationCallbackProvider(cContainer.Resolve<ISessionProvider>()));
            container.Register<IUserMapper>((cContainer, overloads) => new RavenUserMapper(container.Resolve<ISessionProvider>()));
        }

        protected override IEnumerable<Func<Assembly, bool>> AutoRegisterIgnoredAssemblies
        {
            get
            {
                return new List<Func<Assembly, bool>>
                    {
                        assm => !assm.FullName.StartsWith("Nancy", StringComparison.InvariantCultureIgnoreCase),
                        assm => !assm.FullName.StartsWith("Aptitud", StringComparison.InvariantCultureIgnoreCase),
                        assm => !assm.FullName.StartsWith("Glimpse", StringComparison.InvariantCultureIgnoreCase),
                        assm => assm.FullName.StartsWith("Raven", StringComparison.InvariantCultureIgnoreCase),
                    };
            }
        }

        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container,
                                                   Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            FormsAuthentication.Enable(pipelines, new FormsAuthenticationConfiguration
                {
                    RedirectUrl = "~/",
                    UserMapper = container.Resolve<IUserMapper>(),
                });

            StaticConfiguration.EnableRequestTracing = true;
            StaticConfiguration.DisableErrorTraces = false;
        }

        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(
                Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/Content"));
            nancyConventions.StaticContentsConventions.Add(
                Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/Views"));
            nancyConventions.StaticContentsConventions.Add(
                Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/Scripts"));
            nancyConventions.StaticContentsConventions.Add(
                Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("/App"));
        }
    }
}