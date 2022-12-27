using FactoryDesignPattern.Abstract;
using System;

namespace FactoryDesignPattern.Concrete
{
    internal class DesktopScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Desktop Screen");
        }
    }
}
