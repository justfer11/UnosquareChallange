using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using UnosquareChallange.PageObject;

namespace UnosquareChallange.StepsDefinitions
{
    [Binding]
    public sealed class ShoppingCart_Steps
    {
        private readonly IWebDriver _driver;
        private ShoppingCart_PageObj shoppage;

        public ShoppingCart_Steps(IWebDriver driver)
        {
            _driver = driver;
            shoppage = new ShoppingCart_PageObj(_driver);

        }

        [Then(@"I redirect to shopping cart page and verify one element is available")]
        public void ThenIRedirectToShoppingCartPageAndVerifyOneElementIsAvailable()
        {
            shoppage.VerifyElementsShoppingCart();
        }

        [Then(@"I delete the item and verify zero elements are available along with Tu carro está vacio message\.")]
        public void ThenIDeleteTheItemAndVerifyZeroElemtnsAreAvailableAlongWithMessage_()
        {
            shoppage.VerifyItemDeleted();
        }
    }
}
