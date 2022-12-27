using AbstractPattern.Factory;
using FactoryDesignPattern.Factory;

namespace AbstractPattern.FactoryOfFactory
{
    public class MainFactory
    {
        public PhoneFactory CreatePhoneFactory()
        {
            return new PhoneFactory();
        }

        public ScreenFactory CreateScreenFactory()
        {
            return new ScreenFactory();
        }
    }
}
