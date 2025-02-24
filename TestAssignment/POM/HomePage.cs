using OpenQA.Selenium;
using Reqnroll.BoDi;
using TestAssignment.Drivers;
using TestAssignment.Support;

namespace TestAssignment.POM
{
    class HomePage : BasePage
    {
        private static string sectionName(string buttonName) => $"//a[@class='Card_card__3AVip']/h3[text()='{buttonName}']";


        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        protected WaitHelper _waitHelper;

        public HomePage(IObjectContainer objectContainer) : base(objectContainer)
        {
            _driverManager = new DriverManager(objectContainer);
            _waitHelper = new WaitHelper(objectContainer);
            _webDriver = _driverManager.getDriver();
        }

        public HomePage NavigateToSection(string buttonName)
        {
            _waitHelper.ClickWait(sectionName(buttonName)).Click();
            return this;
        }
    }
}
