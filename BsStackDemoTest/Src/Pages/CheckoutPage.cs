﻿using BsStackDemoTest.Src.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BsStackDemoTest.Src.Pages
{
    public class CheckoutPage
    {
        private IWebDriver _driver = null;

        By firstNameTextBox = By.Id("firstNameInput");
        By lastNameTextBox = By.Id("lastNameInput");
        By addressTextBox = By.Id("addressLine1Input");
        By stateTextBox = By.Id("provinceInput");
        By postCodeTextBox = By.Id("postCodeInput");
        By submitShippingButton = By.Id("checkout-shipping-continue");
        By continueShoppingButton = By.CssSelector("div.continueButtonContainer button");

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public ProductsPage FillDetailsAndCheckout()
        {
            try
            {
                _driver.FindElement(firstNameTextBox, 5).SendKeys(ConfigManager.GetTestInputValue("$..first_name"));
                _driver.FindElement(lastNameTextBox).SendKeys(ConfigManager.GetTestInputValue("$..last_name"));
                _driver.FindElement(addressTextBox).SendKeys(ConfigManager.GetTestInputValue("$..address"));
                _driver.FindElement(stateTextBox).SendKeys(ConfigManager.GetTestInputValue("$..state"));
                _driver.FindElement(postCodeTextBox).SendKeys(ConfigManager.GetTestInputValue("$..post_code"));

                _driver.FindElement(submitShippingButton, 5).Click();

                _driver.FindElement(continueShoppingButton, 5).Click();

                return new ProductsPage(_driver);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
