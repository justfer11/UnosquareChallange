using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;

namespace UnosquareChallange.Utils
{
    public class Element
    {
        public static string price;
        private IWebDriver driver;

        public Element(IWebDriver _driver)
        {
            driver = _driver;
        }
        
        public void WaitForElementsLoad()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

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

        public void FluentWait(IWebElement element)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(1);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
        }

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

        public string GetPrice(IWebElement element)
        {
            price = element.Text;
            Console.WriteLine(price);
            return price;
        }

        public string GetElementText(IWebElement element)
        {
                return element.Text;
        }

        public int GetItemAvailable(IWebElement element)
        {
            string text = element.GetAttribute("aria-label");
            int items = Int32.Parse(Regex.Match(text, @"\d").Value);
            Console.WriteLine(items);
            return items;           
        }

        //public static List<Data_Objects> GetText(string text)
        //{
        //    var SearchFile = System.IO.Path.GetTempFileName();
        //    using (TextReader reader = new StreamReader(SearchFile))
        //    {
        //        string jsonTxt = reader.ReadToEnd();
        //        string value = JsonConvert.DeserializeObject<List<Data_Objects>();
        //    }

        //    return null;
        //}


    }
}
