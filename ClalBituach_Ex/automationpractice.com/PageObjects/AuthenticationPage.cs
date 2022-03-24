using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExClalBit.automationpractice.com.PageObjects
{
   public class AuthenticationPage : Header
    {
     public AuthenticationPage (IWebDriver driver) : base(driver) { }

        // --------------------------  Find elements ---------------------------------\\

        private IWebElement emailInput => driver.FindElement(By.CssSelector("#email_create"));
        private IWebElement createBtn => driver.FindElement(By.Id("SubmitCreate"));


        // --------------------------  Action Methods ---------------------------------\\
        public void AccountCreation(string text)
        {
            FillText(emailInput, text);
            Click(createBtn);
        }

        // --------------------------  validation methods ---------------------------------\\

        public string GetRandomEmail()
        {
            string emailText ;
            Random random = new Random();
            int num = random.Next(120, 9999);
            return emailText = num + "test@gmail.com";
        }

    }
}
