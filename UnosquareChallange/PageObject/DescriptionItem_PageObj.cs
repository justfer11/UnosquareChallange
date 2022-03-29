using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using UnosquareChallange.Utils;
using OpenQA.Selenium.Interactions;

namespace UnosquareChallange.PageObject
{
    class DescriptionItem_PageObj
    {
        private IWebDriver _driver;
        private Element element;

        public DescriptionItem_PageObj(IWebDriver driver)
        {
            _driver = driver;
            element = new Element(_driver);
        }

        #region Web Elements
        IWebElement RegisterPopUp => _driver.FindElement(By.Id("email-newsletter-dialog"));
        IWebElement ClosePopUpIcon => _driver.FindElement(By.XPath("//div[@class='sfw-dialog']//div[@class='c-glyph glyph-cancel']"));
        IWebElement PriceLabel => _driver.FindElement(By.XPath("//div[@id='productPrice']//span"));
        IWebElement ShopOptionsBtn => _driver.FindElement(By.Id("ButtonPanel_buttonPanel_OverflowMenuTrigger"));
        IWebElement AddToCart => _driver.FindElement(By.Id("buttonPanel_AddToCartButton"));
        #endregion Web Elements

        //Check whether Registration pop up is displayed or not and close it
        public void CloseRegistrationPopup()
        {
            element.WaitForElementsLoad();
            element.WaitForElementVisible(RegisterPopUp);
            string popup = RegisterPopUp.GetAttribute("aria-hidden");
            if(popup.Equals("false"))
            {
                Assert.IsTrue(element.IsElementClickable(ClosePopUpIcon), "Close pop up icon is not clickable");
            }
        }

        //Compare prices from page results against item description page using a global variable
        public void ComparePrices()
        {
            element.WaitForElementsLoad();
            element.WaitForElementVisible(PriceLabel);
            string listPrice = Element.price;
            Console.WriteLine(listPrice);
            string actualPrice = element.GetElementText(PriceLabel);
            Assert.That(actualPrice.Equals(listPrice), Is.True);
        }

        //Click on Add To Cart... This is a good challange, It wasn't easy to find Add to Cart button in the DOM
        public void ClickOnAddToCart()
        {
            Assert.IsTrue(element.IsElementClickable(ShopOptionsBtn), "Shop option button is not clickable");
            element.WaitForElementVisible(AddToCart);
            Assert.IsTrue(element.IsElementClickable(AddToCart), "Add To Cart button is not clickable");
        }
    }
}
