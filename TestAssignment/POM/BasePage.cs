using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll.BoDi;
using TestAssignment.Drivers;
using TestAssignment.Support;

namespace TestAssignment.POM
{
    abstract class BasePage
    {
        IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        protected Support.WaitHelper _waitHelper;

        public BasePage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _waitHelper = new WaitHelper(_objectContainer);
            _webDriver = _driverManager.getDriver();
        }

        public string GetText(string locator, int timeout = 10)
        {
            IWebElement element = _waitHelper.GetTextWait(locator, timeout);
            return element.FindElement(By.XPath(locator)).Text;
        }


        public BasePage Navigate(string url, int timeout = 10)
        {
            _webDriver.Navigate().GoToUrl(url);
            _waitHelper.NavigateWait(url, timeout);
            return this;
        }

        public void Refresh()
        {
            _webDriver.Navigate().Refresh();
        }

        public BasePage VerifyAlertPopupText(string textMessage)
        {
            Thread.Sleep(1500);
            Assert.AreEqual(textMessage, _webDriver.SwitchTo().Alert().Text,
                $"'{textMessage}' message is not displayed");
            return this;
        }

        public BasePage AcceptAlertPopup()
        {
            Thread.Sleep(1500);
            _webDriver.SwitchTo().Alert().Accept();
            return this;
        }

    }
}
