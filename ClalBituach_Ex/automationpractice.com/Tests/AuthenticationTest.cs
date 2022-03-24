using ExClalBit.automationpractice.com.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExClalBit.automationpractice.com.Tests
{
    [TestClass]
    public class AuthenticationTest : BaseTest
    {
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext testContext)
        {
            BaseTest.TestFixtureSetup(testContext);
        }

        [TestMethod]
        public void Tc_01_AccountCreationEnterValidEmail()
        {
         
            try
            {
                TestName = "Test_01";
                TestDescription = "Account Creation Enter Valid Email";
                test = reports.StartTest(TestName, TestDescription);
                authenticationPage.ClickOnSignIn();
                authenticationPage.AccountCreation(authenticationPage.GetRandomEmail());
                //Thread.Sleep(4000);
                string expectedResult = "CREATE AN ACCOUNT";
                string actualResult = registerPage.titletext.Text;
                Assert.AreEqual(expectedResult, actualResult);
                test.Log(LogStatus.Pass, "The actual Result is passed");
            }
            catch (Exception e)
            {

                test.Log(LogStatus.Fail, "The actual Result is fail. " + " The exception is: " + e.Message);
                Assert.Fail("Test is fail: " + e.Message + test.AddScreenCapture(ScreenShot()));

            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void Tc_02_AccountCreationEnterInvalidEmail(string invalidEmail)
        {
           

            try
            {
                TestName = "Test_02";
                TestDescription = "Account Creation Enter InValid Email";
                test = reports.StartTest(TestName, TestDescription);
                authenticationPage.ClickOnSignIn();
                authenticationPage.AccountCreation(invalidEmail);
                string expectedResult = "account-creation";
                string actualResult = driver.Url;
                Assert.IsFalse(actualResult.Contains(expectedResult));
                test.Log(LogStatus.Pass, "The actual Result is passed");
            }
            catch (Exception e)
            {

                test.Log(LogStatus.Fail, "The actual Result is fail. " + " The exception is: " + e.Message);
                Assert.Fail("Test is fail: " + e.Message + test.AddScreenCapture(ScreenShot()));

            }
        }


        [ClassCleanup]
        public static void TearDoun()
        {
            BaseTest.TearDoun();
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { "testgmail.com" };
            yield return new object[] { "test@" };
            yield return new object[] { "123" };
        }
    }
}
