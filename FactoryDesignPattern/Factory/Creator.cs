using FactoryDesignPattern.Abstract;
using FactoryDesignPattern.Enum;
using FactoryMethodPattern.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Factory
{
    class Creator
    {
        public IScreen ScreenFactory(ScreenType screenType)
        {
            if (screenType == ScreenType.Desktop)
            {
                return new DesktopScreen();
            }
            else if (screenType == ScreenType.Mobile)
            {
                return new MobileScreen();
            }
            else
            {
                return new WebScreen();
            }

        }
    }
}
