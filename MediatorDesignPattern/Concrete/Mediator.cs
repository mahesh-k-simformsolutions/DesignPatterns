using MediatorDesignPattern.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern.Concrete
{
    public class Mediator : IMediator
    {
        private Dictionary<string, User> _baseUsers = new Dictionary<string, User>();
        public void SendMessage(string sender, string receiver, string message)
        {
            User baseUser = _baseUsers[receiver];
            Console.WriteLine($"Message From {receiver}: {message}");
            Console.ReadLine();
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
