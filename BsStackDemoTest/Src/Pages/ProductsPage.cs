using BsStackDemoTest.Src.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace BsStackDemoTest.Src.Pages
{
    public class ProductsPage
    {
        private IWebDriver _driver = null;
        private Navigation _navigation = null;
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            _navigation = new Navigation(_driver);
        }

        public void SelectProductByTitle(string title)
        {
            Thread.Sleep(2000);
            ReadOnlyCollection<IWebElement> items = (ReadOnlyCollection<IWebElement>)_driver.FindElements(By.ClassName("shelf-item"), 10);

            foreach (IWebElement item in items)
            {
                var elementTitle = item.FindElement(By.ClassName("shelf-item__title")).Text;
                if (elementTitle == title)
                {
                    item.FindElement(By.ClassName("shelf-item__buy-btn")).Click();
                    break;
                }
            }
        }

        public CheckoutPage GotoCheckoutPage()
        {
            _driver.FindElement(By.ClassName("buy-btn"), 5).Click();
            return new CheckoutPage(_driver);
        }

        public OrdersPage GotoOrdersPage()
        {
            return _navigation.GotoOrdersPage();
        }
    }
}
