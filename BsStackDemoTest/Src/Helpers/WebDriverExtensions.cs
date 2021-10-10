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
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
                fluentWait.PollingInterval = TimeSpan.FromSeconds(1);
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
                //return wait.Until(drv => drv.FindElements(by));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            return driver.FindElements(by);
        }
    }
}
