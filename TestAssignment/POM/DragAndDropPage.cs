using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll.BoDi;
using TestAssignment.Drivers;
using TestAssignment.Support;

namespace TestAssignment.POM
{
    class DragAndDropPage : BasePage
    {
        public static string itemInMenuTicket(string nameOfItem) => $"//*[@id='menu-items']/li[text()='{nameOfItem}']";
        public static string itemInOrderTicket(string nameOfItem) => $"//*[@id='plate-items']/li[text()='{nameOfItem}']";
        public static string OrderArea = "//*[@id='plate-items']";

        public static string expectedBorderCSSValue = "5px solid rgb(0, 162, 152)";

        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        protected WaitHelper _waitHelper;

        public DragAndDropPage(IObjectContainer objectContainer) : base(objectContainer)
        {
            _driverManager = new DriverManager(objectContainer);
            _waitHelper = new WaitHelper(objectContainer);
            _webDriver = _driverManager.getDriver();
        }

        public DragAndDropPage DragParameterizedMenuItemToOrder(string itemName)
        {
            _waitHelper.DragAndDrop(itemInMenuTicket(itemName), OrderArea);
            return this;
        }

        public DragAndDropPage VerifyItemDisplayedInOrder(string itemName)
        {
            Assert.AreEqual(itemName, _waitHelper.GetTextWait(itemInOrderTicket(itemName)).Text,
                $"{itemName} item is not displayed in Order Ticket area.");
            return this;
        }

        public DragAndDropPage VerifyChangedColorOfTheOrderTicketArea()
        {
            Assert.AreEqual(expectedBorderCSSValue, _waitHelper.GetBorderColor(OrderArea),
                "The Order Ticket Area color was not changed after the drag-and-drop action.");
            return this;
        }
    }
}
