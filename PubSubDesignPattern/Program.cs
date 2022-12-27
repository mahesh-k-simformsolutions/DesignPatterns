
namespace PubSubDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher.Publisher();
            
            var dateSub = new Subscriber.DateTimeSubscriber();
            var daySub = new Subscriber.DaySubscriber();

            publisher.Subscribe(dateSub.Display);
            publisher.Subscribe(daySub.Display);

            publisher.Start();
        }
    }
}
