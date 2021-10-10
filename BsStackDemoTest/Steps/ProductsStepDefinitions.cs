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
    public sealed class ProductsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public ProductsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I select product from the Product page with product title '(.*)'")]
        public void WhenISelectProductFromTheProductPageWithProductTitle(string productTitle)
        {
            ProductsPage productsPage = new ProductsPage(DriverFactory.GetDriver());
            productsPage.SelectProductByTitle(productTitle);
        }

    }
}
