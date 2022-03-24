
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace ExClalBit.automationpractice.com.PageObjects
{
   public class RegisterPage : Header
    {
        public RegisterPage(IWebDriver driver) : base(driver) { }
        
       


        // --------------------------  Find elements ---------------------------------\\
        //private IWebElement mrRadio => driver.FindElement(By.Id("uniform-id_gender1"));
        private IWebElement firstNameInput => driver.FindElement(By.Id("customer_firstname"));
        private IWebElement lastNameInput => driver.FindElement(By.Id("customer_lastname"));
        private IWebElement emailInput => driver.FindElement(By.Id("email"));
        private IWebElement passwordInput => driver.FindElement(By.Id("passwd"));
        private IWebElement daysDrop => driver.FindElement(By.Id("days"));
        private IWebElement monthsDrop => driver.FindElement(By.Id("months"));
        private IWebElement yearsDrop => driver.FindElement(By.Id("years"));
        private IWebElement newsletterCheck => driver.FindElement(By.Id("newsletter"));
        private IWebElement receiveSpecialCheck => driver.FindElement(By.Id("optin"));
        private IWebElement addressFirstNameInput => driver.FindElement(By.Id("firstname"));
        private IWebElement addressLastNameInput => driver.FindElement(By.Id("lastname"));
        private IWebElement companyInput => driver.FindElement(By.Id("company"));
        private IWebElement address1Input => driver.FindElement(By.Id("address1"));
        private IWebElement address2Input => driver.FindElement(By.Id("address2"));
        private IWebElement cityInput => driver.FindElement(By.Id("city"));
        private IWebElement stateInput => driver.FindElement(By.Id("id_state"));
        private IWebElement postalCodeInput => driver.FindElement(By.Id("postcode"));
        private IWebElement countryInput => driver.FindElement(By.Id("id_country"));
        private IWebElement otherInformationInput => driver.FindElement(By.Id("other"));
        private IWebElement homePhoneInput => driver.FindElement(By.Id("phone"));
        private IWebElement mobilePhoneInput => driver.FindElement(By.Id("phone_mobile"));
        private IWebElement assignInput => driver.FindElement(By.Id("alias"));
        private IWebElement registerBtn => driver.FindElement(By.Id("submitAccount"));
        private IWebElement errorMsg => driver.FindElement(By.CssSelector(".alert.alert-danger"));
        public IWebElement titletext => driver.FindElement(By.XPath("//*[@class='page-subheading'][1]"));


        // --------------------------  Action Methods ---------------------------------\\
        public void fillPersonalInformation(string firstNameText , string lastNameText , string emailText , string passwordText, string dateOfBirthText)
        {
            //Click(mrRadio);
            FillText(firstNameInput, firstNameText);
            FillText(lastNameInput, lastNameText);
            FillText(emailInput, GetRandomNumForEmail()+ emailText);
            FillText(passwordInput, passwordText);
            string dayText = dateOfBirthText.Split(' ')[0];
            SelectByValue(daysDrop, dayText);
            string monthText = dateOfBirthText.Split(' ')[1];
            SelectByValue(monthsDrop, monthText);
            string yearText = dateOfBirthText.Split(' ')[2];
            SelectByValue(yearsDrop, yearText);
            Click(newsletterCheck);
            Click(receiveSpecialCheck);
        }


        public void fillAddress(string address1Text , string cityText, string stateText, string postalText , string countryText , string mobilePhoneText, string assignText)
        {
            bool addressFirstName = addressFirstNameInput.GetAttribute("value").Equals(firstNameInput.GetAttribute("value"));
            bool addressLastName = addressLastNameInput.GetAttribute("value").Equals(lastNameInput.GetAttribute("value"));

            if (addressFirstName && addressLastName)
            {
                FillText(companyInput, "ASD");
                FillText(address1Input, address1Text);
                FillText(address2Input, "shivtey israel");
                FillText(cityInput, cityText);
                SelectByText(countryInput, countryText);

                if (countryText.Equals("United States"))
                    SelectByText(stateInput, stateText);

                FillText(postalCodeInput, postalText);
                FillText(otherInformationInput, "bla bla bla");
                FillText(homePhoneInput, "035443453");
                FillText(mobilePhoneInput, mobilePhoneText);
                FillText(assignInput, assignText);
                Click(registerBtn);
            }
            else
            {
                Console.WriteLine("The first name and last name were not transferred to the address details");
                Assert.Fail("The first name and last name were not transferred to the address details");
            }
        }

        // --------------------------  Vlidation Method ---------------------------------\\
        
        public bool IsErrorMsg()
        {
            string msg = "You must register at least one phone number" +
                         "lastname is required" +
                         "firstname is required" +
                         "passwd is required" +
                         "address1 is required" +
                         "city is required" +
                         "The Zip/Postal code you've entered is invalid. It must follow this format: 00000" +
                         "This country requires you to choose a State";
            if (msg.Contains(errorMsg.Text))
                return true;
            else
                return false;
        }

        public string GetRandomNumForEmail()
        {
            
            Random random = new Random();
            int num = random.Next(120, 9999);
            return Convert.ToString(num);
        }








    }
}
