using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDesignPattern.Subscriber
{
    public class DaySubscriber : ISubscriber
    {
        public void Display(DateTime dateTime)
        {
            Console.WriteLine("Day today: " + dateTime.DayOfWeek);
        }
    }
}
