using FactoryDesignPattern.Abstract;
using FactoryDesignPattern.Concrete;
using FactoryDesignPattern.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.Factory
{
    public class ScreenFactory
    {
        public IScreen CreateScreen(ScreenType screenType)
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
