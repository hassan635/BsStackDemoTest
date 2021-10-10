using BsStackDemoTest.Src.Helpers;
using BsStackDemoTest.Src.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BsStackDemoTest.Steps
{
    [Binding]
    public sealed class GenericStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public GenericStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am logged in as (.*)")]
        public void GivenIAmLoggedInAs(string username)
        {
            LoginPage loginPage = new LoginPage(DriverFactory.GetDriver());
            loginPage.LoginAs(username);
        }
    }
}
