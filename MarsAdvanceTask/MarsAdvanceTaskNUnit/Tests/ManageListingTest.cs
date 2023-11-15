using MarsAdvanceTaskNUnit.Steps.ShareSkillSteps;
using MarsAdvanceTaskNUnit.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;

namespace MarsAdvanceTaskNUnit.Tests
{
    [TestFixture, Order(2)]
    public class ManageListingTest : BaseSetUp.BaseSetUp
    {
        SignInSteps SignInStepsObj;
        HomePageSteps HomePageStepsObj;
        AddShareSkillSteps AddShareSkillStepsObj;
        ManageListingsComponentSteps ManageListingsComponentStepsObj;
        SkillDetailsSteps SkillDetailsStepsObj;
        public ManageListingTest()
        {
            SignInStepsObj = new SignInSteps();
            HomePageStepsObj = new HomePageSteps();
            AddShareSkillStepsObj = new AddShareSkillSteps();
            ManageListingsComponentStepsObj = new ManageListingsComponentSteps();
            SkillDetailsStepsObj = new SkillDetailsSteps();
        }
        [Test, Order(2)]
        public void DeleteShareSkill_Test()
        {
            //------Delete skill details------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\DeleteShareSkill.json");
                //Adding Share skill
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Deleting share skill
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteShareSkill"), "Delete Share Skill successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteShareSkill"), "Exception in delete Share Skill");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(2)]
        public void CancelDeleteShareSkill_Test()
        {
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ClickManageListingsTab();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\CancelDeleteShareSkill.json");

                //Cancel deleting share skill
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.CancelDeleteShareSkill(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelDeleteShareSkill"), "Cancel delete Share Skill successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelDeleteShareSkill"), "Exception in cancel delete Share Skill");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(3)]
        public void ActivateShareSkill_Test()
        {
            //------Activate skill details------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ClickManageListingsTab();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\ActivateShareSkill.json");
                //Deleting share skill if exist
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                }
                //Adding hidden share skill 
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Activating share skill
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.ActivateShareSkill(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ActivateShareSkill"), "Activate Share Skill successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ActivateShareSkill"), "Exception in activate Share Skill");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(4)]
        public void DeactivateShareSkill_Test()
        {
            //------Deactivate skill details------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ClickManageListingsTab();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\DeactivateShareSkill.json");
                //Deleting share skill if exist
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                }
                //Adding active share skill 
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                }
                //Deactivating share skill
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.DeactivateShareSkill(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeactivateShareSkill"), "Deactivate Share Skill successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeactivateShareSkill"), "Exception in deactivate Share Skill");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(5)]
        public void NavigateToNextPage_Test()
        {
            //------Navigate to next page------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ClickManageListingsTab();
                ManageListingsComponentStepsObj.NavigateToNextPage();
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToNextPage"), "Navigate to next page successful");
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToNextPage"), "Exception in Navigate to next page");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(6)]
        public void NavigateToPreviousPage_Test()
        {
            //------Navigate to previous page------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ClickManageListingsTab();
                ManageListingsComponentStepsObj.NavigateToPreviousPage();
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToPreviousPage"), "Navigate to previous page successful");
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "NavigateToPreviousPage"), "Exception in previous to next page");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(7)]
        public void WatchSkillDetails_Test()
        {
            //------Watch skill details------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\WatchShareSkillDetails.json");
                //Watch skill details
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.WatchSkillDetails(skill);
                    SkillDetailsStepsObj.ValidateSkillTitle(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "WatchShareSkillDetails"), "Watch skill details successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "WatchShareSkillDetails"), "Exception in watch skill details");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(8)]
        public void UpdateSkillDetails_Test()
        {
            //------Updating skill details------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ClickManageListingsTab();
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\UpdateSkillDetails.json");
                //Edit skill details
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.UpdateSkillDetails(skill);
                    ManageListingsComponentStepsObj.ValidateSkillUpdated(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateSkillDetails"), "Update skill details successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateSkillDetails"), "Exception in update skill details");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(1)]
        public void UpdateInvalidSkillDetails_Test()
        {
            //------Updating invalid skill details------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ClickManageListingsTab();
                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\UpdateInvalidSkillDetails.json");
                //Edit skill details
                foreach (var skill in skillList)
                {
                    ManageListingsComponentStepsObj.UpdateSkillDetails(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidSkillDetails"), "Update invalid skill details successful");
                    AddShareSkillStepsObj.ValidateInvalidMessage();
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.ValidateSkillNotUpdated(skill);
                   
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidSkillDetails"), "Exception in update invalid skill details");
                test.Fail(ex.Message);
            }
        }
    }
}
