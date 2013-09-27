using Nancy;

namespace Aptitud.SimpleCV.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => View["Index"];
        }
    }
}