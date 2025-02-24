using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace TestAssignment.Drivers
{
    class DriverFactory
    {
        private IWebDriver _driver;

        private OptionsFactory options = new OptionsFactory();

        public IWebDriver InitLocalDriver(string browser)
        {
            var webDriverServerPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            switch (browser)
            {
                case "chrome":
                    _driver = new ChromeDriver(webDriverServerPath, options.getChromeOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
                case "firefox":
                    _driver = new FirefoxDriver(webDriverServerPath, options.getFirefoxOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
                case "edge":
                    _driver = new EdgeDriver(webDriverServerPath, options.getEdgeOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
                default:
                    _driver = new ChromeDriver(webDriverServerPath, options.getChromeOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
            }
        }
    }
}
