using AbstractPattern.Concrete;
using AbstractPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPattern.Factory
{
    public class PhoneFactory
    {
        public IPhone CreatePhone(string model, string battery)
        {
            IPhone _phone=null;
            if ("Samsung"==model)
            {
                _phone = new Samsung(model, battery);
            }
            else if ("Iphone"==model)
            {
                _phone = new OnePlus(model,battery);
            }
            return _phone;
        }
    }
}
