using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages;
using MarsAdvanceTaskNUnit.Pages.Components.DescriptionOverview;
using MarsAdvanceTaskNUnit.Steps;
using MarsAdvanceTaskNUnit.Steps.DescriptionSteps;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Tests
{
    [TestFixture, Order(6)]
    public class DescriptionTest : BaseSetUp.BaseSetUp
    {
        SignInSteps SignInStepsObj;
        ActionOnDescriptionSteps ActionOnDescriptionStepsObj;
        DescriptionOverviewSteps DescriptionOverviewStepsObj;
        public DescriptionTest()
        {
            ActionOnDescriptionStepsObj = new ActionOnDescriptionSteps();
            DescriptionOverviewStepsObj = new DescriptionOverviewSteps();
            SignInStepsObj = new SignInSteps();
        }
        [Test, Order(2)]
        public void AddDescription_Test()
        {
            //-----------test for adding/updating description record---------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                //Sigin to Mars
                SignInStepsObj.SignIn();
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddDescription.json");
                //Adding description
                ActionOnDescriptionStepsObj.AddUpdateDescription(descriptionList[0]);
                //Verify the description added
                DescriptionOverviewStepsObj.ValidateDesciption(descriptionList[0]);
                //Attaching screenshot with report
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDescription"), "Add description successful");
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDescription"), "Exception in Add description");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(1)]
        public void AddOutOfLimitDescription_Test()
        {
            //-----------test for adding/updating out of limit description record---------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                //Sigin to Mars
                SignInStepsObj.SignIn();
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddOutOfLimitDescription.json");
                //Adding description
                ActionOnDescriptionStepsObj.AddUpdateOutOfLimitDescription(descriptionList[0]);
                //Attaching screenshot with report
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddOutOfLimitDescription"), "Add out of limit description successful");
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddOutOfLimitDescription"), "Exception in add out of limit description successful");
                test.Fail(ex.Message);
                Assert.Fail();
            }
        }
        [Test, Order(3)]
        public void UpdateOutOfLimitDescription_Test()
        {
            //-----------test for updating out of limit description record---------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                //Sigin to Mars
                SignInStepsObj.SignIn();
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\UpdateOutOfLimitDescription.json");
                //Updating description
                ActionOnDescriptionStepsObj.AddUpdateOutOfLimitDescription(descriptionList[0]);
                //Attaching screenshot with report
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateOutOfLimitDescription"), "Update out of limit description successful");
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateOutOfLimitDescription"), "Exception in update out of limit description successful");
                test.Fail(ex.Message);
                Assert.Fail();
            }
        }
        [Test, Order(4)]
        public void UpdateDescription_Test()
        {
            //----test for updating description record-----
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                //Sigin to Mars
                SignInStepsObj.SignIn();
                List<DescriptionModel> descriptionList = JsonReader.GetData<DescriptionModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\UpdateDescription.json");
                //Updating description
                ActionOnDescriptionStepsObj.AddUpdateDescription(descriptionList[0]);
                //Verify the description updated
                DescriptionOverviewStepsObj.ValidateDesciption(descriptionList[0]);
                //Attaching screenshot with report
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateDescription"), "Update description successful");
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateDescription"), "Exception in update description");
                test.Fail(ex.Message);
                Assert.Fail();
            }
        }
    }
}
