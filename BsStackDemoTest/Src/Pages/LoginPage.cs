using BsStackDemoTest.Src.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BsStackDemoTest.Src.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver = null;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public ProductsPage LoginAs(string username)
        {
            try
            {
                var executor = (IJavaScriptExecutor)_driver;
                executor.ExecuteScript($"sessionStorage.setItem(\"username\", '\"{username}\"');");
                return new ProductsPage(_driver);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProductsPage Logout()
        {
            try
            {
                var executor = (IJavaScriptExecutor)_driver;
                executor.ExecuteScript("sessionStorage.clear();");
                return new ProductsPage(_driver);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
