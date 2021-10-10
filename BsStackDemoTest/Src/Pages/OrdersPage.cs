using BsStackDemoTest.Src.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace BsStackDemoTest.Src.Pages
{
    public class OrdersPage
    {
        private IWebDriver _driver = null;
        private Navigation _navigation = null;
        public OrdersPage(IWebDriver driver)
        {
            _driver = driver;
            _navigation = new Navigation(_driver);
        }

        public List<string> GetOrderTitles()
        {
            try
            {
                ReadOnlyCollection<IWebElement> orderTitleElements = (ReadOnlyCollection<IWebElement>)_driver.FindElements(By.CssSelector("div.a-fixed-left-grid-col.a-col-right > div"), 5);
                List<string> orderTitles = new List<string>();

                foreach (IWebElement orderTitleElement in orderTitleElements)
                {
                    orderTitles.Add(orderTitleElement.Text);
                }

                for (int i = 0; i < orderTitles.Count; i++)
                {
                    orderTitles[i] = orderTitles[i].Replace("Title: ", "");
                }

                return orderTitles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetTotalOrderCost()
        {
            try
            {
                string totalOrderCostText = _driver.FindElement(By.CssSelector("div.a-column.a-span2 div.a-row.a-size-base > span"), 2).Text;
                totalOrderCostText = totalOrderCostText.Replace("$", "");

                return Convert.ToInt32(totalOrderCostText);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
