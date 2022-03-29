using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using UnosquareChallange.Utils;

namespace UnosquareChallange.PageObject
{
    class Window_PageObj
    {
        private IWebDriver _driver;
        private Element element;

        public Window_PageObj(IWebDriver driver)
        {
            _driver = driver;
            element = new Element(_driver);
        }

        IWebElement SearchIcon => _driver.FindElement(By.Id("search"));
        IWebElement SearchTxtbox => _driver.FindElement(By.Id("cli_shellHeaderSearchInput"));
        IWebElement ShoppingTab => _driver.FindElement(By.XPath("//a[contains(@href, '/shop')]"));

        public void SearchItem()
        {
            element.WaitForElementsLoad();            
            element.WaitForElementVisible(SearchIcon);
            Assert.IsTrue(element.IsElementClickable(SearchIcon), "Search Icon is not clickable");
            element.WaitForElementVisible(SearchTxtbox);
            Assert.IsTrue(element.IsElementDisplayed(SearchTxtbox), "Search text box is not displayed");
            var data = DataCollection.GetSearchValue();
            Console.WriteLine(data);
            string text = DataCollection.DeserializeJsonFile(data);
            SearchTxtbox.SendKeys(text);
            SearchIcon.Click();
        }

        public void ClickOnShoppingLink()
        {
            element.WaitForElementsLoad();
            Assert.IsTrue(element.IsElementClickable(ShoppingTab), "Comprar link is not clickable");
        }
    }
}
