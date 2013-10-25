namespace Aptitud.SimpleCV.Web
{
    public interface IConsumerOf<T> 
        where T : EventBase
    {
        void Consume(T message);
    }
}
