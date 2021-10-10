using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace BsStackDemoTest.Src.Helpers
{
    public static class DriverFactory
    {
        private static IWebDriver _driver = null;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
            }

            return _driver;
        }

        public static void NukeDriver()
        {
            try
            {
                _driver.Close();
                _driver.Quit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
