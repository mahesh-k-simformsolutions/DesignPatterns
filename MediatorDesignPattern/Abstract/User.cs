using MediatorDesignPattern.Concrete;
using System;

namespace MediatorDesignPattern.Abstract
{
    public class User
    {
        public string Name { get; set; }
        public Mediator concreteMediator { set; get; }
        public User(string name)
        {
            Name = name;
        }
        public void SendMessage(string receiver, string messsage)
        {
            concreteMediator.SendMessage(Name, receiver, messsage);
        }
        public virtual void MessageReceiver(string sender, string messsage)
        {
            Console.WriteLine("{0} to {1}: '{2}'", sender, Name, messsage);
        }
    }
}
