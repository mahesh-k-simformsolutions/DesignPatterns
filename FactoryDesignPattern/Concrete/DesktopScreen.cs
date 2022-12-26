using FactoryDesignPattern.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Concrete
{
    class DesktopScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Desktop Screen");
        }
    }
}
