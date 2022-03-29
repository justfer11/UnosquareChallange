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

        #region Web Elements

        IWebElement SearchIcon => _driver.FindElement(By.Id("search"));
        IWebElement SearchTxtbox => _driver.FindElement(By.Id("cli_shellHeaderSearchInput"));
        IWebElement ShoppingTab => _driver.FindElement(By.XPath("//a[contains(@href, '/shop')]"));

        #endregion Web Elements

        //Click on Search icon in Windows page
        public void ClicOnSearchButton()
        {
            element.WaitForElementsLoad();
            element.WaitForElementVisible(SearchIcon);
            Assert.IsTrue(element.IsElementClickable(SearchIcon), "Search Icon is not clickable");
        }

        //Look for an Item in the search textbox, using a Json file
        public void SearchItem()
        {
            element.WaitForElementVisible(SearchTxtbox);
            Assert.IsTrue(element.IsElementDisplayed(SearchTxtbox), "Search text box is not displayed");
            var data = DataCollection.GetSearchValue();
            Console.WriteLine(data);
            string text = DataCollection.DeserializeJsonFile(data);
            SearchTxtbox.SendKeys(text);
            SearchIcon.Click();
        }

        //Click on Comprar link
        public void ClickOnShoppingLink()
        {
            element.WaitForElementsLoad();
            Assert.IsTrue(element.IsElementClickable(ShoppingTab), "Comprar link is not clickable");
        }
    }
}
