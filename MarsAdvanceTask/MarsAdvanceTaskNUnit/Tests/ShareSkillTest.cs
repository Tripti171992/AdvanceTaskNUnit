using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Steps.LanguageSteps;
using MarsAdvanceTaskNUnit.Steps;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvanceTaskNUnit.Steps.ShareSkillSteps;

namespace MarsAdvanceTaskNUnit.Tests
{
    [TestFixture, Order(1)]
    public class ShareSkillTest : BaseSetUp.BaseSetUp
    {
        SignInSteps SignInStepsObj;
        HomePageSteps HomePageStepsObj;
        AddShareSkillSteps AddShareSkillStepsObj;
        ManageListingsComponentSteps ManageListingsComponentStepsObj;
        public ShareSkillTest()
        {
            SignInStepsObj = new SignInSteps();
            HomePageStepsObj = new HomePageSteps();
            AddShareSkillStepsObj = new AddShareSkillSteps();
            ManageListingsComponentStepsObj = new ManageListingsComponentSteps();
        }

        [Test, Order(1)]
        public void AddShareSkill_Test()
        {
            //------Add a skill to share------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddSkill.json");
                //Deleting share skill
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.DeleteShareSkill(skill);
                }
                //Adding share skill
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                    ManageListingsComponentStepsObj.ValidateShareSkillAdded(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkill"), "Add share skill successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkill"), "Exception in add share skill");
                test.Fail(ex.Message);
            }

        }

        [Test, Order(2)]
        public void CancelAddShareSkill_Test()
        {
            //------Cancel adding a skill to share------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\CancelAddShareSkill.json");
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.CancelAddShareSkill(skill);
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.ValidateShareSkillNotAdded(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelAddShareSkill"), "Cancel add share skill successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelAddShareSkill"), "Exception in cancel add share skill");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(3)]
        public void AddInvalidShareSkill_Test()
        {
            //------Add an invalid skill to share------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddInvalidShareSkill.json");
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkill(skill);
                    AddShareSkillStepsObj.ValidateInvalidMessage();
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.ValidateShareSkillNotAdded(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidShareSkill"), "Add invalid share skill successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidShareSkill"), "Exception in add invalid share skill");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(4)]
        public void AddShareSkillWithPastEndDate_Test()
        {
            //------Add a skill to share with past end date------
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddSkillWithPastEndDate.json");

                //Adding share skill
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.AddShareSkillWithPastEndDate(skill);
                    HomePageStepsObj.ClickManageListingsTab();
                    ManageListingsComponentStepsObj.ValidateShareSkillNotAdded(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkillWithPastEndDate"), "Add share skill with past end date successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddShareSkillWithPastEndDate"), "Exception in add share skill with past end date");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(5)]
        public void ValidateEmptyTitleValidationMessagel_Test()
        {
            //------Validate error validation message for empty title------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\ValidateEmptyTitleValidationMessage.json");
                //Adding share skill with empty title
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.ValidateEmptyTitleValidationMessage(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyTitleValidationMessage"), "ValidateEmptyTitleValidationMessage successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyTitleValidationMessage"), "Exception in ValidateEmptyTitleValidationMessage");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(6)]
        public void ValidateEmptyDescriptionValidationMessage_Test()
        {
            //------Validate error validation message for empty description------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();

                List<SkillModel> skillList = JsonReader.GetData<SkillModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\ValidateEmptyDescriptionValidationMessage.json");
                //Adding share skill with empty title
                foreach (var skill in skillList)
                {
                    HomePageStepsObj.ClickShareSkillButton();
                    AddShareSkillStepsObj.ValidateEmptyDescriptionValidationMessage(skill);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyDescriptionValidationMessage"), "ValidateEmptyDescriptionValidationMessage successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "ValidateEmptyDescriptionValidationMessage"), "Exception in ValidateEmptyDescriptionValidationMessage");
                test.Fail(ex.Message);
            }
        }
    }
}
