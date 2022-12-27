using AbstractPattern.Factory;
using FactoryDesignPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPattern.FactoryOfFactory
{
    public class MainFactory
    {
        public PhoneFactory CreatePhoneFactory()
        {
            return new PhoneFactory();
        }

        public ScreenFactory CreateScreenFactory()
        {
            return new ScreenFactory();
        }
    }
}
