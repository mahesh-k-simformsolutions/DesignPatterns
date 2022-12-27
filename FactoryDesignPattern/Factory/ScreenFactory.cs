using FactoryDesignPattern.Abstract;
using FactoryDesignPattern.Concrete;
using FactoryDesignPattern.Enum;

namespace FactoryDesignPattern.Factory
{
    public class ScreenFactory
    {
        public IScreen CreateScreen(ScreenType screenType)
        {
            return screenType == ScreenType.Desktop
                ? new DesktopScreen()
                : screenType == ScreenType.Mobile ? new MobileScreen() : new WebScreen();

        }
    }
}
