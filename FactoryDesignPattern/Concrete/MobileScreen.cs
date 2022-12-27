using FactoryDesignPattern.Abstract;
using System;

namespace FactoryDesignPattern.Concrete
{
    internal class MobileScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Mobile Screen");
        }
    }
}
