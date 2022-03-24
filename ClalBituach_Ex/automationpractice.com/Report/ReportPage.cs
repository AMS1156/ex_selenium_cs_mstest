using ExClalBit.automationpractice.com.Utils;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClalBituach_Ex.automationpractice.com.Report
{
    public class ReportPage
    {
        protected static ExtentReports reports;
        protected static ExtentTest test;
        protected static string timeStamp = Convert.ToDateTime(DateTime.Now).ToString("dd--MM--yyyy--mm");

        public static void InitReports()
        {
            Directory.CreateDirectory(UtilsXml.GetData("REPORT_FILE_PATH") + timeStamp);
            reports = new ExtentReports(UtilsXml.GetData("REPORT_FILE_PATH") + timeStamp + UtilsXml.GetData("REPORT_FILE_NAME"));
        }

      public static int RandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 999);
        }

    }
}
