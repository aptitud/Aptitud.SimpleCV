using System;
using Nancy.Testing;

namespace Specs
{
    public static class BrowserExtensions
    {
        public static BrowserResponse Execute(this Browser browser, HttpVerbs verb, Uri path, string json)
        {
            switch (verb)
            {
                case HttpVerbs.Get:
                    return browser.Get(path.ToString(), with => with.AsJson(json));
                case HttpVerbs.Post:
                    return browser.Post(path.ToString(), with => with.AsJson(json));
                case HttpVerbs.Delete:
                    return browser.Delete(path.ToString(), with => with.AsJson(json));
                case HttpVerbs.Head:
                    return browser.Head(path.ToString(), with => with.AsJson(json));
                case HttpVerbs.Patch:
                    return browser.Patch(path.ToString(), with => with.AsJson(json));
                case HttpVerbs.Put:
                    return browser.Put(path.ToString(), with => with.AsJson(json));
                case HttpVerbs.Options:
                    return browser.Options(path.ToString(), with => with.AsJson(json));
                default:
                    return null;
            }
        }

        public static void AsJson(this BrowserContext context, string json)
        {
            context.Body(json);
            context.Header("content-type", "application/json");
        }
    }

    
}
