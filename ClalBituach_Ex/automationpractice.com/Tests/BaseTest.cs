using ClalBituach_Ex.automationpractice.com.Report;
using ExClalBit.automationpractice.com.PageObjects;
using ExClalBit.automationpractice.com.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace ExClalBit.automationpractice.com.Tests
{
    [TestClass]
   public class BaseTest : ReportPage
    {
        protected string TestName { get; set; }
        protected string TestDescription { get; set; }
        
        protected static IWebDriver driver;
        protected static Header header;
        protected static AuthenticationPage authenticationPage;
        protected static RegisterPage registerPage;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext testContext)
        {
            
            //new DriverManager().SetUpDriver(new EdgeConfig());`
            driver = new ChromeDriver();
            //driver = new EdgeDriver();
            driver.Manage().Window.Position = new Point(0, 0);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(UtilsXml.GetData("TIME_OUT")));
            InitPages();
            InitReports();


        }

        [TestInitialize]
        public void Setup() 
        { 
            driver.Navigate().GoToUrl(UtilsXml.GetData("URL"));
           // string testName = TestContext.TestName.Split('_')[0];
           // string testDescription = TestContext.TestName.Split('_')[1];
          //  test = reports.StartTest(testName, testDescription);
        }


        public static void InitPages()
        {
            /* === Initialize pages === */
            header = new Header(driver);
            authenticationPage = new AuthenticationPage(driver);
            registerPage = new RegisterPage(driver);
        }

        [TestCleanup]
        public void CloseTest()
        {
            reports.EndTest(test);
        }
        [ClassCleanup]
        public static void TearDoun()
        {
            reports.Flush();
            reports.Close();
            driver.Quit();
        }

        public static string ScreenShot()
        {

            string location =UtilsXml.GetData("REPORT_FILE_PATH") + timeStamp + "\\Report" + RandomNumber() + ".png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(location, ScreenshotImageFormat.Png);
            return location;

        }
    }
}
