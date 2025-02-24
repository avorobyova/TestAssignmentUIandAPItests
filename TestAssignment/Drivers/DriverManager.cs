using OpenQA.Selenium;
using Reqnroll.BoDi;
using NUnit.Framework;
using Reqnroll;

namespace TestAssignment.Drivers
{

    [Binding]
    class DriverManager
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private DriverFactory driverFactory;
        private static string _browser = "chrome";

        public DriverManager(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            driverFactory = new DriverFactory();
        }

        [BeforeScenario]
        public void SelectBrowser()
        {
            _driver = driverFactory.InitLocalDriver(_browser);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver, "driver");
        }

        public IWebDriver getDriver()
        {
            _driver = _objectContainer.Resolve<IWebDriver>("driver");
            return _driver;
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
