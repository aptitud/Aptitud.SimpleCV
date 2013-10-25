using System;
using System.Collections.Generic;
using System.Linq;
using Aptitud.SimpleCV.Raven;
using Nancy.TinyIoc;
using Raven.Client;

namespace Aptitud.SimpleCV.Web.Services.Eventing
{
    public class EventsDispatcher
    {
        public static void Send(IEnumerable<EventBase> events)
        {
            if(events == null)
                return;

            var sessionProvider = TinyIoCContainer.Current.Resolve<ISessionProvider>();

            foreach (var @event in events)
            {
                var consumerInterfaceType = typeof (IConsumerOf<>).MakeGenericType(@event.GetType());
                var consumers = typeof (EventsDispatcher).Assembly.GetTypes().Where(consumerInterfaceType.IsAssignableFrom).ToList();

                foreach (var consumer in consumers)
                {
                    var instance = Activator.CreateInstance(consumer);
                    IDocumentSession session = null;

                    var needRavenSession = instance as INeedRavenSession;
                    if (needRavenSession != null)
                    {
                        session = sessionProvider.GetSession();
                        session.Advanced.UseOptimisticConcurrency = true;
                        needRavenSession.RavenSession = session;
                    }

                    try
                    {
                        instance.GetType().GetMethod("Consume").Invoke(instance, new[] {@event});
                        if (session == null)
                            continue;

                        session.SaveChanges();
                    }
                    catch (Exception exception)
                    {
                        throw new ApplicationException("Exception occured in Consume!", exception);
                    }
                    finally
                    {
                        if(session != null)
                            session.Dispose();
                    }
                }
            }
        }
    }
}