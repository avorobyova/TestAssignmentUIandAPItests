using System;
using Reqnroll;
using TestAssignment.POM;
using NUnit.Framework.Interfaces;


namespace TestAssignment.StepDefinitions
{
    [Binding]
    class KitchenApplitoolsStepDefinitions
    {
        private HomePage _homePage;
        private DragAndDropPage _dragAndDropPage;

        public KitchenApplitoolsStepDefinitions(HomePage homePage, DragAndDropPage dragAndDropPage)
        {
            _homePage = homePage;
            _dragAndDropPage = dragAndDropPage;
        }

        [Given("Kitchen Applitools homepage is opened")]
        public void GivenKitchenApplitoolsHomepageIsOpened()
        {
            _homePage.Navigate("https://kitchen.applitools.com/");
        }

        [When("Navigate to the {string} section")]
        public void WhenNavigateToTheSection(string sectionName)
        {
            _homePage.NavigateToSection(sectionName);
        }

        [When("Drag a {string} item from Menu to the Order Ticket area")]
        public void WhenDragAItemFromMenuToTheOrderTicketArea(string itemName)
        {
            _dragAndDropPage.DragParameterizedMenuItemToOrder(itemName);
        }

        [Then("I should see the text inside the Order Ticket matches {string} item")]
        public void ThenIShouldSeeTheTextInsideTheOrderTicketMatchesItem(string itemName)
        {
            _dragAndDropPage.VerifyItemDisplayedInOrder(itemName);
        }

        [Then("I should see the changed color of the Order Ticket area")]
        public void ThenIShouldSeeTheChangedColorOfTheOrderTicketArea()
        {
            _dragAndDropPage.VerifyChangedColorOfTheOrderTicketArea();
            
        }
    }
}
