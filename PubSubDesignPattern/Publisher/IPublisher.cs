using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDesignPattern.Publisher
{
    public interface IPublisher
    {
        void Subscribe(DateTimeDelegate dateTimeHandler);
    }
}
