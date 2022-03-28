using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnosquareChallange.Utils
{
    [Binding]
    class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private static IWebDriver webdriver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]

        public void BeforeScenario()
        {
            webdriver = new ChromeDriver(@"C:\driver\web");
            webdriver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs<IWebDriver>(webdriver);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            webdriver.Quit();
        }
    }
}
