using BsStackDemoTest.Src.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BsStackDemoTest.Src.Pages
{
    public class Navigation
    {
        private IWebDriver _driver = null;

        public Navigation(IWebDriver driver)
        {
            _driver = driver;
        }

        public OrdersPage GotoOrdersPage()
        {
            _driver.FindElement(By.Id("orders"), 2).Click();
            return new OrdersPage(_driver);
        }
    }
}
