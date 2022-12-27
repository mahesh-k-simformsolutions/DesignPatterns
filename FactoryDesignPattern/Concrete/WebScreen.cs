using FactoryDesignPattern.Abstract;
using System;

namespace FactoryDesignPattern.Concrete
{
    internal class WebScreen : IScreen
    {
        public void Draw()
        {
            Console.WriteLine("Web Screen");
        }
    }
}
