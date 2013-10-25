using Aptitud.SimpleCV.Web.Services;
using Raven.Client;

namespace Aptitud.SimpleCV.Web.Features.ProfileList
{
    public class ProfileListConsumer : INeedRavenSession, IConsumerOf<NewProfileCreated>
    {
        public IDocumentSession RavenSession { set; private get; }

        public void Consume(NewProfileCreated message)
        {
            RavenSession.Store(new ProfileListViewModel
                {
                    Name = message.Name,
                    Email = message.Email,
                });
        }
    }
}