using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages;
using MarsAdvanceTaskNUnit.Pages.Components.ProfileMenuTabNavigationOverview;
using MarsAdvanceTaskNUnit.Pages.Components.ProfileOverview;
using MarsAdvanceTaskNUnit.Pages.Components.ShareSkillOverview;
using MarsAdvanceTaskNUnit.Pages.Components.SignInOverview;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Steps
{
    public class HomePageSteps
    {
        HomePage HomePageComponentObj;
        ProfileOverviewComponents ProfileOverviewComponentsObj;
        ShareSkillComponent ShareSkillComponentObj;
        ProfileMenuTabOverviewComponent ProfileMenuTabOverviewComponentObj;
        public HomePageSteps()
        {
            HomePageComponentObj = new HomePage();
            ProfileOverviewComponentsObj = HomePageComponentObj.GetProfileOverviewComponents();
            ShareSkillComponentObj = HomePageComponentObj.GetShareSkillComponent();
            ProfileMenuTabOverviewComponentObj = HomePageComponentObj.GetProfileMenuTabOverviewComponent();
        }
        public void ValidateFirstName()
        {
            //--------Validate first name--------
            try
            {
                List<UserInformation> userList = JsonReader.GetData<UserInformation>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\MarsAdvancedTasks\\MarsAdvancedTasks\\AdvancedTaskNUnit\\AdvancedTaskNUnit\\JsonObject\\UserInformation.json");

                //Verify if user is taken to their home page upon login in to Mars 
                string expectedUserName = "Hi " + userList[0].firstName;
                string actualUserName = HomePageComponentObj.GetFirstName();
                Assert.AreEqual(expectedUserName, actualUserName, "Actual and expected username do not match.User not logged in successfully !!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateNotSignedIn(UserInformation user)
        {
            //Validate user is not signed in--------
            try
            {
                //Verify if user is not taken to their home page upon login into Mars with invalid credentials
                string expectedUserName = "Hi " + user.firstName;
                string actualUserName = HomePageComponentObj.GetFirstName();
                Assert.AreNotEqual(expectedUserName, actualUserName, "Actual and expected username match.User logged in successfully !!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        public void ClickOnCertificationTab()
        {
            //--------Click certification tab--------
            ProfileOverviewComponentsObj.ClickCertificationTab();
        }

        public void ClickOnEducationTab()
        {
            //--------Click education tab--------
            ProfileOverviewComponentsObj.ClickEducationTab();
        }

        public void ClickOnLangaugesTab()
        {
            //--------Click languages tab--------
            ProfileOverviewComponentsObj.ClickLangaugesTab();
        }

        public void ClickOnSkillsTab()
        {
            //--------Click Skills tab--------
            ProfileOverviewComponentsObj.ClickSkillsTab();
        }
        public void ClickShareSkillButton()
        {
            //--------Click Share skill button--------
            ShareSkillComponentObj.ClickShareSkillButton();
        }
        public void ClickDashboardTab()
        {
            //--------Click dashboard tab--------
            ProfileMenuTabOverviewComponentObj.ClickDashboardTab();
        }
        public void ClickProfileTab()
        {
            //--------Click Profile tab--------
            ProfileMenuTabOverviewComponentObj.ClickProfileTab();
        }
        public void ClickManageListingsTab()
        {
            //--------Click manage listings tab--------
            ProfileMenuTabOverviewComponentObj.ClickManageListingsTab();
        }
        public void ClickReceivedRequestsTab()
        {
            //--------Click received requests tab--------
            ProfileMenuTabOverviewComponentObj.ClickReceivedRequestsTab();
        }
        public void ClickSentRequestsTab()
        {
            ////--------Click sent requests tab--------
            ProfileMenuTabOverviewComponentObj.ClickSentRequestsTab();
        }
    }
}
