using AbstractPattern.Concrete;
using AbstractPattern.Interface;

namespace AbstractPattern.Factory
{
    public class PhoneFactory
    {
        public IPhone CreatePhone(string model, string battery)
        {
            IPhone _phone = null;
            if ("Samsung" == model)
            {
                _phone = new Samsung(model, battery);
            }
            else if ("Iphone" == model)
            {
                _phone = new OnePlus(model, battery);
            }
            return _phone;
        }
    }
}
