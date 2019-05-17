using System;
using TechTalk.SpecFlow;
using System.Threading;
using SpecflowPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using static SpecflowPages.CommonMethods;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        #region TestCase 1 - Add new language
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            CommonMethods.Wait(3000);

            // Click on Languages tab 
            Driver.driver.FindElement(By.XPath("//a[text() = 'Languages']")).Click();


        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            try
            {
                //Click on Add New button under Language tab
                Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//div[text() = 'Add New']")).Click();

                //Add new Language - not existing language
                Driver.driver.FindElement(By.XPath("//input[@placeholder = 'Add Language']")).SendKeys("English");

                //Select the Basic level from the Language level
                SelectElement obj = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab = 'first']//select[@name= 'level']")));
                obj.SelectByText("Basic");

                //Click on Add button
                Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//input[@value = 'Add']")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                string ExpectedValue = "English";

                //Get all the Language values in the List
                IList<IWebElement> langList = Driver.driver.FindElements(By.XPath("//div[@data-tab = 'first' ]//table//tr/td[1]"));
                Console.WriteLine(langList);

                bool matchLang = false;
                foreach (IWebElement lang in langList)
                {
                    if (ExpectedValue == lang.Text)
                    {
                        test.Log(LogStatus.Pass, "Test Passed: New Language added successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        matchLang = true;
                        Assert.IsTrue(true);
                    }


                }

                if (matchLang == false)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail();

                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                Assert.Fail();
            }


        }
        #endregion

        #region TestCase 2 - Adding 3 more languages with scenarioOutline
        [Given(@"I click on the Language tab to add multiple records")]
        public void GivenIClickOnTheLanguageTabToAddMultipleRecords()
        {
            CommonMethods.Wait(3000);
            // Click on Languages tab 
            Driver.driver.FindElement(By.XPath("//a[text() = 'Languages']")).Click();
        }

        [When(@"I enter '(.*)' and '(.*)' and click add new button")]
        public void WhenIEnterAndAndClickAddNewButton(string p0, string p1)
        {
            //Click on Add New button under Language tab
            Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//div[text() = 'Add New']")).Click();

            //Add new Language - not existing language
            Driver.driver.FindElement(By.XPath("//input[@placeholder = 'Add Language']")).SendKeys(p0);

            //Select the Basic level from the Language level
            SelectElement obj = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab = 'first']//select[@name= 'level']")));
            obj.SelectByText(p1);

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//input[@value = 'Add']")).Click();
        }

        [Then(@"the record '(.*)' should be added to the list")]
        public void ThenTheRecordShouldBeAddedToTheList(string p0)
        {
            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Delete the first Language record");

            string ExpectedValue = p0;

            //Get all the Language values in the List
            IList<IWebElement> langList = Driver.driver.FindElements(By.XPath("//div[@data-tab = 'first' ]//table//tr/td[1]"));
            Console.WriteLine(langList);

            bool matchLang = false;
            foreach (IWebElement lang in langList)
            {
                if (ExpectedValue == lang.Text)
                {
                    test.Log(LogStatus.Pass, "Test Passed: New Language added successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                    matchLang = true;
                    Assert.IsTrue(true);
                }
            }

            if (matchLang == false)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail();

            }
        }

        #endregion

        #region TestCase 2- Duplicate addition

        [Given(@"I click on the language tab to add existing language")]
        public void GivenIClickOnTheLanguageTabToAddExistingLanguage()
        {
            CommonMethods.Wait(3000);
            // Click on the Language tabe inside profile page
            Driver.driver.FindElement(By.XPath("//a[text() = 'Languages']")).Click();

        }

        [When(@"I add the duplicate language")]
        public void WhenIAddTheDuplicateLanguage()
        {
            try
            {
                //Click on Add New button under Language tab
                Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//div[text() = 'Add New']")).Click();

                //Add a language value which is already existing
                Driver.driver.FindElement(By.XPath("//input[@placeholder = 'Add Language']")).SendKeys("English");

                //Select the Conversational level from the Language level
                SelectElement obj = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab = 'first']//select[@name= 'level']")));
                obj.SelectByText("Basic");

                //Click on Add button
                Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//input[@value = 'Add']")).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [Then(@"The seller should not allow to add")]
        public void ThenTheSellerShouldNotAllowToAdd()
        {

            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Add a duplicate Language");
            //get the message from the popup box
            try
            {
                String actualMessage = Driver.driver.FindElement(By.XPath("//div[contains(@class, 'ns-box-inner')]")).Text;
                string expectedMessage = "This language is already exist in your language list.";
                if (actualMessage == expectedMessage)
                {

                    test.Log(LogStatus.Pass, "Test Passed: Not allowed to add duplicate language");
                    Assert.IsTrue(true);

                }
                else
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    Assert.Fail();

                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                Assert.Fail();
            }


        }
        #endregion

        #region TestCase3 - Edit the values
        [Given(@"I click on the language tab to check edit")]
        public void GivenIClickOnTheLanguageTabToCheckEdit()
        {
            CommonMethods.Wait(3000);
            // Click on the Language tabe inside profile page
            Driver.driver.FindElement(By.XPath("//a[text() = 'Languages']")).Click();
        }
        [When(@"I click edit button and change the language level")]
        public void WhenIClickEditButtonAndChangeTheLanguageLevel()
        {
            //click on the Edit button corresponding to English language
            //string editBtnXpath = "//div[@data-tab = 'first' ]//table//tr[1]/td[3]";
            string editBtnXpath = "//div[@data-tab = 'first' ]//td[text()= 'English']/following-sibling::td[@class]//i[@class = 'outline write icon']";
            if (CommonMethods.isElementPresent(By.XPath(editBtnXpath)))
            {
                Driver.driver.FindElement(By.XPath(editBtnXpath)).Click();
            }

            // Change the level from Basic to conversational in language level - make sure level should be other than conversational before edit
            SelectElement obj = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab = 'first']//select[@name= 'level']")));
            obj.SelectByText("Conversational");

            //Click on the Update button
            Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//input[@value = 'Update']")).Click();


        }
        [Then(@"The language level should be updated with new info")]
        public void ThenTheLanguageLevelShouldBeUpdatedWithNewInfo()
        {
            //Extent report intialization
            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Edit the Language level");

            String actualMessage = Driver.driver.FindElement(By.XPath("//div[contains(@class, 'ns-box-inner')]")).Text;
            string expectedMessage = "English has been updated to your languages";
            if (actualMessage == expectedMessage)
            {
                test.Log(LogStatus.Pass, "Test Passed: Not allowed to add duplicate language");
                Assert.IsTrue(true);
            }
            else
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail();
            }
        }
        #endregion

        #region TestCase 4- Max limit of records
        [Given(@"I click on the language tab to check max limit")]
        public void GivenIClickOnTheLanguageTabToCheckMaxLimit()
        {
            CommonMethods.Wait(3000);
            // Click on the Language tabe inside profile page
            Driver.driver.FindElement(By.XPath("//a[text() = 'Languages']")).Click();
        }
        [When(@"I try to add fifth record")]
        public void WhenITryToAddFifthRecord()
        {
            //Added code in the following function - not much validation required, since the Add new button is not visible


        }
        [Then(@"The seller should not allo to add")]
        public void ThenTheSellerShouldNotAlloToAdd()
        {
            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Max Limit check - Trying to add fifth recod");

            string addNewBtnXpath = "//div[@data-tab = 'first']//div[text() = 'Add New']";
            // Driver.driver.FindElement(By.XPath("//div[@data-tab = 'first']//div[text() = 'Add New']"));
            if (CommonMethods.isElementPresent(By.XPath(addNewBtnXpath)))
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail();
            }
            else
            {
                test.Log(LogStatus.Pass, "Test Passed: Not showing Add new button");
                Assert.IsTrue(true);
            }
        }
        #endregion

        #region TestCase 5 - Delete the record
        [Given(@"I click on the language tab to check Delete function")]
        public void GivenIClickOnTheLanguageTabToCheckDeleteFunction()
        {
            CommonMethods.Wait(3000);
            // Click on the Language tabe inside profile page
            Driver.driver.FindElement(By.XPath("//a[text() = 'Languages']")).Click();
        }

        [When(@"I click on the delete icon for the first record")]
        public void WhenIClickOnTheDeleteIconForTheFirstRecord()
        {
            //Click on the delete icon for the first language record 
                string deleteBtnXpath = "//tbody[1]//*[@class = 'remove icon']";
                Driver.driver.FindElement(By.XPath(deleteBtnXpath)).Click();
         }

        [Then(@"The record should be deleter from the list\.")]
        public void ThenTheRecordShouldBeDeleterFromTheList_()
        {
            CommonMethods.ExtentReports();
            CommonMethods.test = CommonMethods.extent.StartTest("Delete the first Language record");

            String actualMessage = Driver.driver.FindElement(By.XPath("//div[contains(@class, 'ns-box-inner')]")).Text;
            string expectedMessage = "has been deleted from your languages";
            if (actualMessage.Contains(expectedMessage))
            {

                test.Log(LogStatus.Pass, "Test Passed: The record deleted");
                Assert.IsTrue(true);

            }
            else
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail();

            }

        }
        #endregion
    }
}

