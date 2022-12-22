using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Concrete
{
    class MobileScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Mobile Screen");
        }
    }
}
