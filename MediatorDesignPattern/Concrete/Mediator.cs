using MediatorDesignPattern.Abstract;
using System;
using System.Collections.Generic;

namespace MediatorDesignPattern.Concrete
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<string, User> _baseUsers = new();
        public void SendMessage(string sender, string receiver, string message)
        {
            _ = _baseUsers[receiver];
            Console.WriteLine($"Message From {receiver}: {message}");
            _ = Console.ReadLine();
        }

        public void SignIn(User baseUser)
        {
            if (!_baseUsers.ContainsValue(baseUser))
            {
                _baseUsers[baseUser.Name] = baseUser;
            }
            baseUser.concreteMediator = this;
        }
    }
}
