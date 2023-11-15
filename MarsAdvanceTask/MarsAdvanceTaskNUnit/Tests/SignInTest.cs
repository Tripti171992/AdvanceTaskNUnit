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
    [TestFixture, Order(3)]
    public class SignInTest : BaseSetUp.BaseSetUp
    {
        SignInSteps SignInStepsObj;
        HomePageSteps HomePageStepsObj;
        public SignInTest()
        {
            SignInStepsObj = new SignInSteps();
            HomePageStepsObj = new HomePageSteps();
        }

        [Test, Order(1)]
        public void SignIn_Test()
        {
            //------Sign in------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                HomePageStepsObj.ValidateFirstName();
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignIn"), "successful sign in");
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignIn"), "Exception in Signin");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(2)]
        public void SignInInvalid_Test()
        {
            //------Invalid sign in------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

                List<UserInformation> userList = JsonReader.GetData<UserInformation>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\InvalidUserInformation.json");
                foreach (var user in userList)
                {
                    SignInStepsObj.SignInInvalid(user);
                    HomePageStepsObj.ValidateNotSignedIn(user);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignInInvalid"), "successful sign in invalid");
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignInValid"), "Exception in Signin invalid");
                test.Fail(ex.Message);
            }
        }
    }
}
