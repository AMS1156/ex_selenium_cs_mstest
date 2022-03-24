using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using RelevantCodes.ExtentReports;

namespace ExClalBit.automationpractice.com.Tests
{
    [TestClass]
   public class RegisterTest : BaseTest
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext testContext)
        {
            BaseTest.TestFixtureSetup(testContext);
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\automationpractice.com\\Data\\ValidPrametersForRegisterPage.csv", "ValidPrametersForRegisterPage#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Tc_01_FillingInRegistrationValidInformation()
        {
              try
            {
                TestName = "Test_01";
                TestDescription = "Filling In Registration Valid Information";
                test = reports.StartTest(TestName, TestDescription);
                registerPage.ClickOnSignIn();
                authenticationPage.AccountCreation(authenticationPage.GetRandomEmail());
                registerPage.fillPersonalInformation(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString(), TestContext.DataRow[2].ToString(), TestContext.DataRow[3].ToString(),
                    TestContext.DataRow[4].ToString());

                registerPage.fillAddress(TestContext.DataRow[5].ToString(), TestContext.DataRow[6].ToString(), TestContext.DataRow[7].ToString(),
                    TestContext.DataRow[8].ToString(), TestContext.DataRow[9].ToString(), TestContext.DataRow[10].ToString(), TestContext.DataRow[11].ToString());
                string expectedResult = "My account";
                string actualResult = driver.Title;
                Assert.IsTrue(actualResult.Contains(expectedResult));
                test.Log(LogStatus.Pass, "The actual result is passed");

            }
            catch (Exception e)
            {
                test.Log(LogStatus.Fail, "The actual result is fail. " + " The exception is: " + e.Message);
                Assert.Fail("Test is fail: " + e.Message + test.AddScreenCapture(ScreenShot()));

            } 
            
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\automationpractice.com\\Data\\InValidPrametersForRegisterPage.csv", "InValidPrametersForRegisterPage#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Tc_02_FillingInRegistrationInValidInformation()
        {
            try
            {
                TestName = "Test_02";
                TestDescription = "Filling In Registration InValid Information";
                test = reports.StartTest(TestName, TestDescription);
                registerPage.ClickOnSignIn();
                authenticationPage.AccountCreation(authenticationPage.GetRandomEmail());
                registerPage.fillPersonalInformation(TestContext.DataRow[0].ToString(), TestContext.DataRow[1].ToString(), TestContext.DataRow[2].ToString(), TestContext.DataRow[3].ToString(),
                    TestContext.DataRow[4].ToString());

                registerPage.fillAddress(TestContext.DataRow[5].ToString(), TestContext.DataRow[6].ToString(), TestContext.DataRow[7].ToString(),
                    TestContext.DataRow[8].ToString(), TestContext.DataRow[9].ToString(), TestContext.DataRow[10].ToString(), TestContext.DataRow[11].ToString());
                string expectedResult = "Login - My Store";
                string actualResult = driver.Title;
                Assert.AreEqual(expectedResult, actualResult);
                test.Log(LogStatus.Pass, "The actual result is passed");
            }
            catch (Exception e)
            {
                test.Log(LogStatus.Fail, "The actual result is fail. " + " The exception is: " + e.Message);
                Assert.Fail("Test is fail: " + e.Message + test.AddScreenCapture(ScreenShot()));
            }
           
        }



        [ClassCleanup]
        public static void TearDoun()
        {
            BaseTest.TearDoun();
        }

     
    }
}
