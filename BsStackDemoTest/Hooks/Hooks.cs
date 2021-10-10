using BsStackDemoTest.Src.Helpers;
using BsStackDemoTest.Src.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BsStackDemoTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static IWebDriver _driver = null;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _driver = DriverFactory.GetDriver();
            _driver.Manage().Window.Maximize();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver.Navigate().GoToUrl("https://bstackdemo.com/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Navigation navigation = new Navigation(_driver);
            //navigation.Logout();
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.Logout();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            DriverFactory.NukeDriver();
        }

    }
}
