using BsStackDemoTest.Src.Helpers;
using BsStackDemoTest.Src.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;

namespace BsStackDemoTest.Steps
{
    [Binding]
    public sealed class OrdersStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        public OrdersStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"The product title '(.*)' on the Orders page should be identical to Product Page")]
        public void ThenTheProductTitleOnTheOrdersPageShouldBeIdenticalToProductPage(string expectedOrderTitle)
        {
            ProductsPage productsPage = new ProductsPage(DriverFactory.GetDriver());
            OrdersPage ordersPage = productsPage.GotoOrdersPage();
            Assert.True(ordersPage.GetOrderTitles().Contains(expectedOrderTitle));
        }

        [Then(@"The total order cost should be '(.*)'")]
        public void ThenTheTotalOrderCostShouldBe(int expectedTotalOrderCost)
        {
            ProductsPage productsPage = new ProductsPage(DriverFactory.GetDriver());
            OrdersPage ordersPage = productsPage.GotoOrdersPage();
            Assert.AreEqual(expectedTotalOrderCost, ordersPage.GetTotalOrderCost());
        }

    }
}
