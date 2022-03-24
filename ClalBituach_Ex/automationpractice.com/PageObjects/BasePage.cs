using ClalBituach_Ex.automationpractice.com.Report;
using ExClalBit.automationpractice.com.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExClalBit.automationpractice.com.PageObjects
{
    public class BasePage : ReportPage
    {
		protected IWebDriver driver;
		protected WebDriverWait Wait;
		protected SelectElement select;
		
		public BasePage(IWebDriver driver)
		{

			this.driver = driver;
			Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			
		}

		// -------------  Fill in a text field ---------------------------------
		public void FillText(IWebElement el, string text)
		{
			try
			{
				el.Clear();
				el.SendKeys(text);
				test.Log(LogStatus.Pass, "SendKeys of element is passed");
			}
			catch (Exception e)
			{

				test.Log(LogStatus.Fail, "SendKeys of element is fail " + e.Message);
				Assert.Fail("test is fail" + e.Message + test.AddScreenCapture(BaseTest.ScreenShot()));

			}
		}

		public  void Click(IWebElement el)
		{
			try
			{
				el.Click();
				test.Log(LogStatus.Pass, "click of element is passed");
			}
			catch (Exception e)
			{
				test.Log(LogStatus.Fail, "click of element is fail " + e.Message);
				Assert.Fail("test is fail" + e.Message + test.AddScreenCapture(BaseTest.ScreenShot()));
			}
		}

		public void DoubelClick(IWebElement el)
		{
			
			try
			{
				Thread.Sleep(3000);
				el.Click();
				el.Click();
				test.Log(LogStatus.Pass, "DrupDoun of element is passed");
			}
			catch (Exception e)
			{
				test.Log(LogStatus.Fail, "DrupDoun of element is fail" + e.Message);
				Assert.Fail("test is fail" + e.Message + test.AddScreenCapture(BaseTest.ScreenShot()));
			}
		}

		public string GetText(IWebElement el)
		{
			return el.Text;
		}


		// -------------  Handling Select  ---------------------------------

		public void SelectByValue(IWebElement el, string value)
		{
			
			try
			{
				select = new SelectElement(el);
				select.SelectByValue(value);
				test.Log(LogStatus.Pass, "DrupDoun of element is passed");
			}
			catch (Exception e)
			{
				test.Log(LogStatus.Fail, "DrupDoun of element is fail" + e.Message);
				Assert.Fail("test is fail" + e.Message + test.AddScreenCapture(BaseTest.ScreenShot()));
			}
		}

		public void SelectByText(IWebElement el, string text)
		{
			
			try
			{
				select = new SelectElement(el);
				select.SelectByText(text);
				test.Log(LogStatus.Pass, "DrupDoun of element is passed");
			}
			catch (Exception e)
			{
				test.Log(LogStatus.Fail, "DrupDoun of element is fail: " + e.Message);
				Assert.Fail("test is fail" + e.Message + test.AddScreenCapture(BaseTest.ScreenShot()));
			}
		}

		public void SelectByIndex(IWebElement el, int index)
		{
			try
			{
				select = new SelectElement(el);
				select.SelectByIndex(index);
				test.Log(LogStatus.Pass, "DrupDoun of element is passed");
			}
			catch (Exception e)
			{
				test.Log(LogStatus.Fail, "DrupDoun of element is fail" + e.Message);
				Assert.Fail("test is fail" + e.Message + test.AddScreenCapture(BaseTest.ScreenShot()));
			}
		}
	}
}
