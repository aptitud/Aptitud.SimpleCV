using System;
using Nancy;
using Nancy.Testing;
using TechTalk.SpecFlow;
using Xunit;

namespace Specs.Features.Consultant
{
    [Binding]
    public class CreateNewConsultantFromAuthenticationInformationSteps
    {
        private BrowserResponse _result;

        [Then(@"email (.*) should have a profile")]
        public void ThenEmailHaveAProfile(string email)
        {
            using (var session = BrowserProvider.GetSession())
            {
                Assert.NotNull(session.Load<Aptitud.SimpleCV.Model.Consultant>(email));
            }
        }

        [Given(@"email (.*) doesn't have a profile")]
        public void GivenEmailDoesnTHaveAProfile(string email)
        {
            using (var session = BrowserProvider.GetSession())
            {
                Assert.Null(session.Load<Aptitud.SimpleCV.Model.Consultant>(email));
            }
        }

        [When(@"executing (.*) to (.*) containing")]
        public void WhenExecutingToContaining(HttpVerbs verb, Uri path, string jsonString)
        {
            var browser = BrowserProvider.GetBrowser();
            _result = browser.Execute(verb, path, jsonString);
        }

        [Then(@"the HttpStatusCode should be (.*)")]
        public void ThenTheHttpStatusCodeShouldBe(HttpStatusCode status)
        {
            Assert.Equal(status, _result.StatusCode);
        }

        [Then(@"with header location (.*)")]
        public void ThenWithHeaderLocation(string path)
        {
            Assert.Equal(path, _result.Headers["location"]);
        }
    }
}
