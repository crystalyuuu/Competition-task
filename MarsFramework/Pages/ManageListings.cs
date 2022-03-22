using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using static NUnit.Core.NUnitFramework;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);

        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing                 
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i")]
        private IWebElement view { get; set; }

        ////View first record
        //[FindsBy(How = How.XPath, Using = "(//i[@class='skill-title'])[1]")]
        //private IWebElement firstRecord { get; set; }

        ////First share skill Title, click view and find the title name in the top row.
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[1]/div/div/div/div")]
        private IWebElement firstRecordSkillTitle { get; set; }

        ////Delete button of the first record in the Listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i")]
        private IWebElement deletetherecord { get; set; }

        ////Click on 'YES' button to delete record
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement yes { get; set; }


        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }


        //Function for viewing listings
        internal void viewListings()
        {
            Thread.Sleep(2000);
            manageListingsLink.Click();

            Thread.Sleep(2000);
            view.Click();
        }


        //Function for getting firt record title
        public string getFirstRecordTitle()
        {
            manageListingsLink.Click();

            Thread.Sleep(2000);
            view.Click();

            Thread.Sleep(2000);
            firstRecordSkillTitle.Click();
            return firstRecordSkillTitle.Text;
        }


        //Function for editing listings
        public string editListings()
        {
            Thread.Sleep(2000);
            manageListingsLink.Click();

            Thread.Sleep(2000);
            edit.Click();

            ShareSkill shareSkill = new ShareSkill();
            shareSkill.EditShareSkill();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");

            Thread.Sleep(2000);
            string expectedTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            return expectedTitle;

        }


        //Function for deleting listings
        public string deleteListings()
        {
            Thread.Sleep(2000);
            manageListingsLink.Click();

            Thread.Sleep(2000);
            deletetherecord.Click();

            yes.Click();

            Thread.Sleep(2000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");

            Thread.Sleep(2000);
            string expectedTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            string expectedMessage = expectedTitle + " has been deleted";
            return expectedMessage;
        }


        //Function for get pop up message for deleting share skill
        public string getPopUpMessage()
        {
            //Deleted message
            String message = GlobalDefinitions.driver.FindElement(By.XPath(@"//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
            return message;
        }
    }
}


