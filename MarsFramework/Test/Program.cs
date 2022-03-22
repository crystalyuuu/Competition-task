using MarsFramework.Pages;
using NUnit.Framework;
using System;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            //[Test]
            //public void Test()
            //{
            //}


            // Test adding share skill
            [Test, Order(1)]
            public void A_AddNewShareSkill()
            {
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();
            }

            // Test viewing manage share skill
            [Test, Order(2)]
            public void B_ViewShareSkill()
            {
                ManageListings manageListing = new ManageListings();
                manageListing.viewListings();
                string firstSkillTitle = manageListing.getFirstRecordTitle();
                Assert.That(firstSkillTitle == "Selenium", "Title doest not match");
            }

            // Test editing manage share skill
            [Test, Order(3)]
            public void C_EditManageListings()
            {
                ManageListings managelistings = new ManageListings();
                string expectedtitle = managelistings.editListings();
                string firstskilltitle = managelistings.getFirstRecordTitle();
                Assert.That(firstskilltitle == expectedtitle, "Title doest not match");
            }

            // Test delecting listing
            [Test, Order(4)]
            public void D_DeleteListings()
            {
                ManageListings managelistings = new ManageListings();
                string message = managelistings.deleteListings();
                string actualmessage = managelistings.getPopUpMessage();
                Assert.AreEqual(message, actualmessage);
            }

        }
    }
}