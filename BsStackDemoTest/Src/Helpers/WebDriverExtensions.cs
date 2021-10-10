using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BsStackDemoTest.Src.Helpers
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                /*
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(by));
                }
                return driver.FindElement(by);
                */
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(10);
                fluentWait.PollingInterval = TimeSpan.FromSeconds(timeoutInSeconds);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
                fluentWait.Message = "Element to be searched not found";

                return fluentWait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static IWebElement FindElement(this IWebElement element, IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                /*
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(by));
                }
                return driver.FindElement(by);*/

                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(10);
                fluentWait.PollingInterval = TimeSpan.FromSeconds(timeoutInSeconds);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
                fluentWait.Message = "Element to be searched not found";

                return fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static IReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElements(by));
            }
            return driver.FindElements(by);
        }
    }
}
