using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using UnosquareChallange.PageObject;
using UnosquareChallange.Utils;

namespace UnosquareChallange.StepsDefinitions
{
    [Binding]
    public sealed class MicrosoftPage_Steps : ConstructURL
    {
        private readonly IWebDriver _driver;
        private Microsoft_PageObj mspage;
        private string page;
        private string locale;

        public MicrosoftPage_Steps(IWebDriver driver)
        {
            _driver = driver;
            mspage = new Microsoft_PageObj(_driver);

        }

        //Using an Abstract Class:
        public override void Create_URL()
        {
            string completeURL = "https://www." + page + ".com" + "/" + locale + "/"; ;
            _driver.Url = completeURL;
        }

        [Given(@"I go to '(.*)' in '(.*)' locale")]
        public void GivenIGoToInLocale(string page, string locale)
        {
            this.page = page;
            this.locale = locale;
            Create_URL();
        }

        [Given(@"I go to Windows page")]
        public void GivenIGoToWindowsPage()
        {
            mspage.ClickWindowsLink();
        }
    }
}
