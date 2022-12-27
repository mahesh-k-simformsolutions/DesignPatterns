using FactoryDesignPattern.Abstract;
using FactoryDesignPattern.Enum;
using FactoryDesignPattern.Factory;
using System;

namespace FactoryDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScreenFactory creator = new ScreenFactory();
            IScreen desktop = creator.CreateScreen(ScreenType.Desktop);
            IScreen mobile = creator.CreateScreen(ScreenType.Mobile);
            desktop.Draw();
            mobile.Draw();
        }
    }
}
