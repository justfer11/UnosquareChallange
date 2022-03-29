using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using UnosquareChallange.Utils;
using NUnit.Framework;

namespace UnosquareChallange.PageObject
{
    class Application_PageObj
    {
        private IWebDriver _driver;
        private Element element;
        int SubTotalElements = 0;
        int TotalElements = 0;

        public Application_PageObj(IWebDriver driver)
        {
            _driver = driver;
            element = new Element(_driver);
        }
        
        #region Web Elements
        IWebElement AppLink => _driver.FindElement(By.XPath("//a[@name='refine'][contains(@href, '/shop/apps')]"));
        IWebElement PageOneLink => _driver.FindElement(By.XPath("//ul[@class='m-pagination']//a[contains(text(), 1)]"));
        IWebElement PageTwoLink => _driver.FindElement(By.XPath("//ul[@class='m-pagination']//a[contains(text(), 2)]"));
        IWebElement PageThreeLink => _driver.FindElement(By.XPath("//ul[@class='m-pagination']//a[contains(text(), 3)]"));
        IWebElement FirsItemPrice => _driver.FindElement(By.XPath("(//span[1][@aria-hidden='false'])[1]"));
        #endregion Web Elements

        //Click on AppLink from Application Page
        public void ClickOnAppLink()
        {
            element.WaitForElementVisible(AppLink);
            Assert.IsTrue(element.IsElementClickable(AppLink), "App link is not clickable");
        }

        //Count all elements in the page(1, 2, 3)
        public int CountElements()
        {
            element.WaitForElementsLoad();
            //All images (items) in the results page
            int Elements = _driver.FindElements(By.XPath("//div[@class= 'c-channel-placement-image']")).Count();
            //All Items titles in the results page
            int Titles = _driver.FindElements(By.XPath("//h3[@class= 'c-subheading-6']")).Count();
            //All subtitles (Gratis or Price) in the results page
            int Subtitles = _driver.FindElements(By.XPath("//div[@class= 'c-channel-placement-price']")).Count;
            SubTotalElements = Elements + Titles + Subtitles;
            Console.WriteLine(SubTotalElements);
            return SubTotalElements;
        }

        //Count all elements in the page2 + page1
        public void ClickOnPage2()
        {
            element.WaitForElementVisible(PageTwoLink);
            PageTwoLink.Click();
            Console.WriteLine("SubTotal: " + SubTotalElements);
            TotalElements = SubTotalElements + CountElements();
            Console.WriteLine(TotalElements);
        }

        //Count all elements in the page3 + page2
        public void ClickOnPage3()
        {
            element.WaitForElementVisible(PageThreeLink);
            PageThreeLink.Click();
            Console.WriteLine(TotalElements);
            TotalElements = TotalElements + CountElements();
            Console.WriteLine($"TotalElements in the 3 first pages is: {TotalElements}");
        }

        //Print sum of all elements in the page 1, 2, 3
        public void PrintTotals()
        {
            Console.WriteLine($"TotalElements in the 3 first pages is: {TotalElements}");
        }

        //Return to Page 1
        public void BackToPage1()
        {
            element.WaitForElementVisible(PageOneLink);
            PageOneLink.Click();
        }

        //Select First NonFree Item in the results page
        public void SelectFirstNonFreeItem()
        {
            element.WaitForElementVisible(FirsItemPrice);
            element.GetPrice(FirsItemPrice);
            Assert.IsTrue(element.IsElementClickable(FirsItemPrice), "First item with price is not clickable");
        }
    }
}
