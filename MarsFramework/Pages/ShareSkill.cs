using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static NUnit.Core.NUnitFramework;



namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }


        //// Monday Checkbox selected
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Mon { get; set; }

        //// Monday Starttime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input")]
        private IWebElement MonStartTime { get; set; }

        //// Monday Endtime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]
        private IWebElement MonEndTime { get; set; }


        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on WorkSample upload
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }


        //// Share skill pop up error message : Please complete the form correctly.
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement PopUpError { get; set; }

        //// Delete tag
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span/a")]
        private IWebElement RemoveTag { get; set; }

        //// Delete the skill-Exchange
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/span/a")]
        private IWebElement RemoveSkillExchageTag { get; set; }


        // Function for adding new share skill
        internal void EnterShareSkill()
        {
            //Click shareskill button
            Thread.Sleep(2000);
            ShareSkillButton.Click();

            //Populating the excel data
            Thread.Sleep(2000);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Reading the Titile data from excel
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Reading the Description data from excel
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Click on Category dropdown button and select option
            CategoryDropDown.Click();
            SelectElement categoryselect = new SelectElement(CategoryDropDown);
            categoryselect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Click on Subcategory dropdown button and select option
            SubCategoryDropDown.Click();
            SelectElement subcategoryselect = new SelectElement(SubCategoryDropDown);
            subcategoryselect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Adding tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Servicetype
            //ServiceTypeOptions.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceTypeOptions"));
            //Locationtype
            //LocationTypeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));

            //Start date
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            //End date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //Click on Monday checkbox
            string day = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
            if (day == "Mon")
            {
                Mon.Click();
            }

            //Monday Start Time
            MonStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));

            //Monday End Time
            MonEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            //Skill Trade Option
            //SkillTradeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTradeOption"));

            //Skill Exchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);

            //WorkSample Upload
            WorkSample.Click();

            Thread.Sleep(000);
            //ActiveOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Active"));
            Save.Click();

            //Checking for shareskill updatation successfull   
            if (PopUpError.Text == "Please complete the form correctly.")
            {
                Console.WriteLine(PopUpError.Text);
            }
            else
            {
                Console.WriteLine("ShareSkill Saved");
            }
        }

        // Function for editing share skill
        internal void EditShareSkill()
        {
            //Populating the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");
            Thread.Sleep(2000);

            //Clear the Titile textbox
            Title.Clear();

            //Reading the edit Titile data from excel
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Clear the Description textbox
            Description.Clear();

            //Reading the edit Titile data from excel
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Click on Category dropdown and edit
            CategoryDropDown.Click();
            SelectElement categoryselect = new SelectElement(CategoryDropDown);
            categoryselect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Click on Subcategory dropdown and edit
            SubCategoryDropDown.Click();
            SelectElement subcategoryselect = new SelectElement(SubCategoryDropDown);
            subcategoryselect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Removing Existing Tags
            RemoveTag.Click();

            //Adding new tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            ///Servicetype
            //ServiceTypeOptions.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceTypeOptions"));
            //Locationtype
            //LocationTypeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));

            
            Thread.Sleep(2000);
            //Eidt Start Date
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            //Eidt End Date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //Click on the day
            string day = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
            if (day == "Mon")
            {
                Mon.Click();
            }

            //Edit Start Time
            MonStartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));

            //Edit End Time
            MonEndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            //Skill Trade Option
            //SkillTradeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));

            //Click on Remove the Skill-Exchangetag
            RemoveSkillExchageTag.Click();

            //Edit skill exchange Tags
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            //WorkSample Upload
            WorkSample.Click();

            //ActiveOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Active"));

            //After editing and click on Save button
            Save.Click();

        }

    }
}
