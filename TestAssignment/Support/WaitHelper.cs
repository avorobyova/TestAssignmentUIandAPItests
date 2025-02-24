using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Reqnroll.BoDi;
using SeleniumExtras.WaitHelpers;
using TestAssignment.Drivers;

namespace TestAssignment.Support
{
    public class WaitHelper
    {
        private IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        private WebDriverWait wait;

        public WaitHelper(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _webDriver = _driverManager.getDriver();
            wait = new WebDriverWait(new SystemClock(),
                                     _webDriver,
                                     TimeSpan.FromSeconds(10),
                                     sleepInterval: TimeSpan.FromMilliseconds(100));
        }

        public void SetUpWait(int timeout = 10)
        {
            wait.Timeout = TimeSpan.FromSeconds(timeout);
        }
        public void NavigateWait(string url, int timeout = 10)
        {
            SetUpWait(timeout);
            string shortURL = url.Replace("https:", "").Replace("http:", "");
            wait.Until(ExpectedConditions.UrlContains(shortURL));
            return;
        }
        public IWebElement ClickWait(string locator, int timeout = 10)
        {
            SetUpWait(timeout);
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            ScrollToView(element);
            element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
            return element;
        }

        public IWebElement GetTextWait(string locator, int timeout = 10)
        {
            SetUpWait(timeout);
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            ScrollToView(element);
            return element;
        }

        public void ScrollToView(IWebElement element)
        {
            Actions actionProvider = new Actions(_webDriver);
            var jsDriver = (IJavaScriptExecutor)_webDriver;

            // Performs mouse move action onto the element
            try
            {
                jsDriver.ExecuteScript("window.scrollTo(0,document.body.scrollHeight);", element);

                actionProvider.MoveToElement(element).Build().Perform();
            }
            catch { }
        }

        public void DragAndDrop(string fromElementLocator, string toElementLocator)
        {
            Actions actionProvider = new Actions(_webDriver);
            actionProvider.DragAndDrop(GetTextWait(fromElementLocator), GetTextWait(toElementLocator)).Build().Perform();
            return;
        }

        public string GetBorderColor(string locator, int timeout = 10)
        {
            SetUpWait(timeout);
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
            string hexColor = element.GetCssValue("border");
            return hexColor;
        }

        public IWebElement ExistsWait(string locator, int timeout = 10)
        {
            SetUpWait(timeout);
            Thread.Sleep(1000);
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));
            return element;
        }
    }
}
