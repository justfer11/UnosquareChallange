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
    public sealed class WindowsPage_Steps
    {
        private readonly IWebDriver _driver;
        private Window_PageObj winpage;

        public WindowsPage_Steps(IWebDriver driver)
        {
            _driver = driver;
            winpage = new Window_PageObj(_driver);

        }

        [When(@"I search for Xbox item")]
        public void WhenISearchForItems()
        {
            winpage.SearchItem();
        }

        [Then(@"I go to Comprar page")]
        public void ThenIGoToComprarPage()
        {
            winpage.ClickOnShoppingLink();
        }
    }
}
