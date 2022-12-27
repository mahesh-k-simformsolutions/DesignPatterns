using AbstractPattern.FactoryOfFactory;
using AbstractPattern.Interface;
using FactoryDesignPattern.Abstract;
using System;

namespace AbstractPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainFactory factory = new();
            var screenFactory = factory.CreateScreenFactory();
            var phoneFactory = factory.CreatePhoneFactory();
            IScreen screen = screenFactory.CreateScreen(FactoryDesignPattern.Enum.ScreenType.Desktop);
            screen.Draw();

            IPhone phone = phoneFactory.CreatePhone("Samsung", "500mah");
            Console.WriteLine(phone.ToString());

            Console.ReadLine();
        }
    }

}
