using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Text;

namespace ExClalBit.automationpractice.com.PageObjects
{
    public class Header : BasePage
    {
        public Header (IWebDriver driver) : base(driver) {
        }

        // --------------------------  Find elements ---------------------------------\\
        private IWebElement signInBtn => driver.FindElement(By.XPath("//*[@class='login']"));


        // --------------------------  Action Methods ---------------------------------\\
        public void ClickOnSignIn()
        {
            Click(signInBtn);
        }
    }
}
