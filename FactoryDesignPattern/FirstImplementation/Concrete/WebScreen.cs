using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Concrete
{
    class WebScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Web Screen");
        }
    }
}
