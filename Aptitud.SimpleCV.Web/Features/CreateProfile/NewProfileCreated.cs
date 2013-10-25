namespace Aptitud.SimpleCV.Web
{
    public class NewProfileCreated : EventBase
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}