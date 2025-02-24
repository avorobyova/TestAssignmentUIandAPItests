using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestAssignment.Drivers
{
    class OptionsFactory
    {
        public ChromeOptions getChromeOptions()
        {
            string[] arguments = {"--start-maximized", "--ignore-certificate-errors",
                "--disable-popup-blocking", "--no-sandbox" , "--disable-dev-shm-usage"};
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = true;
            chromeOptions.AddArguments(arguments);

            return chromeOptions;
        }
        public FirefoxOptions getFirefoxOptions()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AcceptInsecureCertificates = true;

            return firefoxOptions;
        }
        public EdgeOptions getEdgeOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AcceptInsecureCertificates = true;

            return edgeOptions;
        }
    }
}
