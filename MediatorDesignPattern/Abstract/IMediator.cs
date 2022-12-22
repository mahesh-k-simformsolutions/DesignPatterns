using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern.Abstract
{
    public interface IMediator
    {
        public void SignIn(User baseUser);

        public void SendMessage(string sebder, string receiver, string message);
    }
}
