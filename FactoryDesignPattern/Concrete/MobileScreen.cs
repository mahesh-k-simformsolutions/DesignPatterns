using FactoryDesignPattern.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Concrete
{
    class MobileScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Mobile Screen");
        }
    }
}
