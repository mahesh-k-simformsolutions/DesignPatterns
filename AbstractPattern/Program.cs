using AbstractPattern.FactoryOfFactory;
using AbstractPattern.Interface;
using FactoryDesignPattern.Abstract;
using System;

namespace AbstractPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MainFactory factory = new();
            FactoryDesignPattern.Factory.ScreenFactory screenFactory = factory.CreateScreenFactory();
            Factory.PhoneFactory phoneFactory = factory.CreatePhoneFactory();
            IScreen screen = screenFactory.CreateScreen(FactoryDesignPattern.Enum.ScreenType.Desktop);
            screen.Draw();

            IPhone phone = phoneFactory.CreatePhone("Samsung", "500mah");
            Console.WriteLine(phone.ToString());

            _ = Console.ReadLine();
        }
    }

}
