using FactoryMethodPattern;
using FactoryMethodPattern.Enum;
using FactoryMethodPattern.Factory;
using System;

namespace FactoryDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new Creator();
            IScreen desktop = creator.ScreenFactory(ScreenType.Desktop);
            IScreen mobile = creator.ScreenFactory(ScreenType.Mobile);
            desktop.Draw();
            mobile.Draw();
        }
    }
}
