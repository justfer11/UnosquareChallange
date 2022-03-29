using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace UnosquareChallange.Utils
{
    public class Element
    {
        //Global Variable to get price
        public static string price;

        private IWebDriver driver;

        public Element(IWebDriver _driver)
        {
            driver = _driver;
        }
        
        //Implicit wait
        public void WaitForElementsLoad()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        //Explicit wait
        public void WaitForElementVisible(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until<bool>((d) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        //Using Fluentwait for the elements
        public void FluentWait(IWebElement element)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(1);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
        }

        //Return true or false if element is not displayed
        public bool IsElementDisplayed(IWebElement element)
        {
            FluentWait(element);
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //Return true or false if element is not clickable
        public bool IsElementClickable(IWebElement element)
        {
            FluentWait(element);
            try
            {
                element.Click();
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }

        //Get Price from an element and save it in Global variable
        public string GetPrice(IWebElement element)
        {
            price = element.Text;
            Console.WriteLine(price);
            return price;
        }

        //Get Text from an Element
        public string GetElementText(IWebElement element)
        {
                return element.Text;
        }

        //Get Count of Items inside of Shopping Cart
        public int GetItemAvailable(IWebElement element)
        {
            string text = element.GetAttribute("aria-label");
            int items = Int32.Parse(Regex.Match(text, @"\d").Value);
            Console.WriteLine(items);
            return items;           
        }
    }
}
