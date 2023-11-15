using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Steps;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Tests
{
    [TestFixture, Order(4)]
    public class RegistrationTest : BaseSetUp.BaseSetUp
    {
        RegistrationSteps RegistrationStepsObj;
        public RegistrationTest()
        {
            RegistrationStepsObj = new RegistrationSteps();
        }

        [SetUp]
        public override void SetActions()
        {
            Initialize();
            NavigateUrl();
        }
        [Test, Order(1)]
        public void RegistrationInvalid_Test()
        {
            //------Register with invalid details------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                List<RegistrationModel> userList = JsonReader.GetData<RegistrationModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\MarsAdvancedTasks\\MarsAdvancedTasks\\AdvancedTaskNUnit\\AdvancedTaskNUnit\\JsonObject\\RegistrationInvalidInformation.json");
                foreach (var user in userList)
                {
                    RegistrationStepsObj.RegistrationInvalid(user);
                    RegistrationStepsObj.ValidateRegistrationInvalid();
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationInvalid"), "Registration sign in invalid");
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationInvalid"), "Registration in Signin invalid");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(2)]
        public void RegistrationExistingCredentials_Test()
        {
            //------Register with existing credentials------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                List<RegistrationModel> userList = JsonReader.GetData<RegistrationModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\MarsAdvancedTasks\\MarsAdvancedTasks\\AdvancedTaskNUnit\\AdvancedTaskNUnit\\JsonObject\\RegistrationExistingCredentials.json");
                foreach (var user in userList)
                {
                    RegistrationStepsObj.RegistrationInvalid(user);
                    RegistrationStepsObj.ValidateRegistrationInvalid();
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationInvalid"), "Registration sign in invalid");
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "RegistrationInvalid"), "Registration in Signin invalid");
                test.Fail(ex.Message);
            }
        }
    }
}
