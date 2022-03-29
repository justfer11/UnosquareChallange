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
    class Microsoft_PageObj
    {
        private IWebDriver _driver;
        private Element element;

        public Microsoft_PageObj(IWebDriver driver)
        {
            _driver = driver;
            element = new Element(_driver);
        }
        IWebElement WindowsLink => _driver.FindElement(By.XPath("//li[@class='single-link js-nav-menu uhf-menu-item']//a[@href='https://www.microsoft.com/es-mx/windows/']"));

        //Click on Windows link in Microsoft page
        public void ClickWindowsLink()
        {
            Assert.IsTrue(element.IsElementClickable(WindowsLink), "Windows link is not clickable");
        }
    }
}
