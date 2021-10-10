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
    public sealed class CheckoutStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CheckoutStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I checkout the product\(s\)")]
        public void WhenICheckoutTheProduct()
        {
            ProductsPage productsPage = new ProductsPage(DriverFactory.GetDriver());
            CheckoutPage checkoutPage = productsPage.GotoCheckoutPage();
            checkoutPage.FillDetailsAndCheckout();
        }
    }
}
