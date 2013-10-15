using TechTalk.SpecFlow;

namespace Specs
{
    [Binding]
    public class DocumentStoreHandler
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            BrowserProvider.CreateInMemoryDocumentStore(true);
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
