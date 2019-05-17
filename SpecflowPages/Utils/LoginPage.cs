using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SpecflowPages.CommonMethods;
//*** Description: 
// 14-05-2019: Sudha - haven't done much changes.
// Used the existing Login step to login to the portal. Added new xpaths and my credentials to enter 
// the profile page.
namespace SpecflowPages.Utils
{
  public class LoginPage
    {
        public static void LoginStep()
        {
            //Navigate to the Url
            Driver.NavigateUrl();
            Thread.Sleep(1000);

            //Click on Sign up button
            Driver.driver.FindElement(By.XPath("//a[text() = 'Sign In']")).Click();

            //Enter Username
            Driver.driver.FindElement(By.XPath("//input[@name = 'email']")).SendKeys("sudha86.tumu@gmail.com");

            //Enter password
            Driver.driver.FindElement(By.XPath("//input[@name = 'password']")).SendKeys("test@123");
            Thread.Sleep(1000);
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[text() = 'Login']")).Click();

            //string msg = "Add New Job";
            //string Actualmsg = Driver.driver.FindElement(By.XPath("//*[@id='addnewjob']")).Text;

            //if (msg == Actualmsg)
            //{
                //Console.WriteLine("Test Passed");
                //CommonMethods.ExtentReports();
                //Thread.Sleep(500);
                //test = CommonMethods.extent.StartTest("Login with valid data");
                //Thread.Sleep(1000);
                //CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                //SaveScreenShotClass.SaveScreenshot(Driver.driver, "HomePage");
            //}
            //else
            //{
                //Console.WriteLine("Test Failed");
                //CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            //}
        }

    }
}
