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
    public sealed class ItemDetailedPage_Steps
    {
        private readonly IWebDriver _driver;
        private DescriptionItem_PageObj dItempage;

        public ItemDetailedPage_Steps(IWebDriver driver)
        {
            _driver = driver;
            dItempage = new DescriptionItem_PageObj(_driver);
        }

        [Then(@"I close Registration pop up")]
        public void ThenICloseRegistrationPopUp()
        {
            dItempage.CloseRegistrationPopup();
        }

        [Then(@"I compare the price from the items list view vs item detailed page")]
        public void ThenICompareThePriceFromTheItemsListViewVsItemDetailedPage()
        {
            dItempage.ComparePrices();
        }

        [When(@"I click on add to cart from the three dots next to comprar button")]
        public void WhenIClickOnAddToCartFromTheThreeDotsNextToComprarButton()
        {
            dItempage.ClickOnAddToCart();
        }
    }
}
