using BsStackDemoTest.Src.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            try
            {
                ReadOnlyCollection<IWebElement> items = (ReadOnlyCollection<IWebElement>)_driver.FindElements(By.ClassName("shelf-item"), 5);

                var executor = (IJavaScriptExecutor)_driver;

                foreach (IWebElement item in items)
                {
                    var elementTitle = item.FindElement(By.ClassName("shelf-item__title")).Text;
                    if (elementTitle == title)
                    {
                        executor.ExecuteScript("arguments[0].click();", item.FindElement(By.ClassName("shelf-item__buy-btn")));
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CheckoutPage GotoCheckoutPage()
        {
            try
            {
                var executor = (IJavaScriptExecutor)_driver;
                executor.ExecuteScript("arguments[0].click();", _driver.FindElement(By.ClassName("buy-btn")));
                return new CheckoutPage(_driver);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OrdersPage GotoOrdersPage()
        {
            return _navigation.GotoOrdersPage();
        }
    }
}
