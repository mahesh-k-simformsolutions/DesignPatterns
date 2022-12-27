using FactoryDesignPattern.Abstract;
using FactoryDesignPattern.Enum;
using FactoryDesignPattern.Factory;

namespace FactoryDesignPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ScreenFactory creator = new();
            IScreen desktop = creator.CreateScreen(ScreenType.Desktop);
            IScreen mobile = creator.CreateScreen(ScreenType.Mobile);
            desktop.Draw();
            mobile.Draw();
        }
    }
}
