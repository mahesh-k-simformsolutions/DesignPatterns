using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDesignPattern.Subscriber
{
    public interface ISubscriber
    {
        void Display(DateTime dateTime);
    }
}
