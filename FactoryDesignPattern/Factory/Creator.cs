using FactoryMethodPattern.Concrete;
using FactoryMethodPattern.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern.Factory
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
