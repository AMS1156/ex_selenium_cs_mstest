using ExClalBit.automationpractice.com.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExClalBit.automationpractice.com.Tests
{
    [TestClass]
    public class HeaderTest : BaseTest {


        [ClassInitialize]
        public static void TestFixtureSetup(TestContext testContext)
        {
            BaseTest.TestFixtureSetup(testContext);
        }
        
        [TestMethod]
        public void Tc_01_ClickOnSignIn()
        {
            try
            {
                TestName = "Test_01";
                TestDescription = "Click on SignIn";
                test = reports.StartTest(TestName, TestDescription);
                header.ClickOnSignIn();
                string expectedResult = "Login - My Store";
                string actualResult = driver.Title;
                Assert.AreEqual(expectedResult, actualResult);
                test.Log(LogStatus.Pass, "The actual result is passed!");
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
