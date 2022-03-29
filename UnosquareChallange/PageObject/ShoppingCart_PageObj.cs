using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using UnosquareChallange.Utils;

namespace UnosquareChallange.PageObject
{
    class ShoppingCart_PageObj
    {
        private IWebDriver _driver;
        private Element element;

        public ShoppingCart_PageObj(IWebDriver driver)
        {
            _driver = driver;
            element = new Element(_driver);
        }

        #region Web Elements
        IWebElement CartTitle => _driver.FindElement(By.XPath("//h2[@class='header--+mZZyTaz c-heading x-hidden-focus']"));
        IWebElement CartIcon => _driver.FindElement(By.Id("uhf-shopping-cart"));
        IWebElement RemoveItemButton => _driver.FindElement(By.XPath("//div[@class='legalAndStatementContainer--dz8EQOG7']//button[1]"));
        IWebElement CartEmptyMessage => _driver.FindElement(By.XPath("//p[@class='c-paragraph-2']"));
        #endregion Web Elements

        //Validate if item is available in Cart
        public void VerifyElementsShoppingCart()
        {
            element.WaitForElementsLoad();
            element.WaitForElementVisible(CartTitle);
            Assert.True(element.IsElementDisplayed(CartTitle), "Cart title is not displayed");
            element.WaitForElementVisible(CartIcon);
            element.WaitForElementsLoad();
            int items = element.GetItemAvailable(CartIcon);
            Assert.That(items.Equals(1), Is.True);
        }

        //Validate if item is not available in Cart anymore after removing it
        public void VerifyItemDeleted()
        {
            Assert.True(element.IsElementClickable(RemoveItemButton), "Remove Item button is not clickable");
            element.WaitForElementsLoad();
            element.WaitForElementVisible(CartEmptyMessage);
            Assert.True(element.IsElementDisplayed(CartEmptyMessage), "Cart empty message is not displayed");
            element.WaitForElementVisible(CartIcon);
            int items = element.GetItemAvailable(CartIcon);
            Assert.That(items.Equals(0), Is.True);
        }
    }
}
