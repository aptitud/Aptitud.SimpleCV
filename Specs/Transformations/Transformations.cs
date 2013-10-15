using System;
using TechTalk.SpecFlow;

namespace Specs.Transformations
{
    [Binding]
    public class Transformations
    {
        [StepArgumentTransformation]
        public Uri ConvertPath(string path)
        {
            Uri uri = null;
            Uri.TryCreate(path, UriKind.Relative, out uri);
            return uri;
        }
    }
}
