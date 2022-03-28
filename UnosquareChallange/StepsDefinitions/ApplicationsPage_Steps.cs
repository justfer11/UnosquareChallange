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
    public sealed class ApplicationsPage_Steps
    {
        private readonly IWebDriver _driver;
        private Application_PageObj apppage;

        public ApplicationsPage_Steps(IWebDriver driver)
        {
            _driver = driver;
            apppage = new Application_PageObj(_driver);
        }

        [Then(@"I go to Aplicaciones view")]
        public void ThenIGoToAplicacionesView()
        {
            apppage.ClickOnAppLink();
        }

        [When(@"I count the elements in the three first pages")]
        public void WhenICountTheElementsInTheFirstPages()
        {
            apppage.CountElements();
            apppage.ClickOnPage2();
            apppage.ClickOnPage3();
        }

        [Then(@"I print the sum of all elements and titles")]
        public void ThenIPrintTheSumOfAllElementsAndTitles()
        {
            apppage.PrintTotals();
        }

        [When(@"I back to first page")]
        public void WhenIBackToFirstPage()
        {
            apppage.BackToPage1();
        }

        [Then(@"I select first NON-FREE option and store the price")]
        public void ThenISelectFirstNON_FREEOptionAndStoreThePrice()
        {
            apppage.SelectFirstNonFreeItem();
        }

    }
}
