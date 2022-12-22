using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Concrete
{
    class DesktopScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Desktop Screen");
        }
    }
}
