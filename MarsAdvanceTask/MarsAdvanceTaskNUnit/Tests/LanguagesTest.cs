using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages.Components.ProfileOverview;
using MarsAdvanceTaskNUnit.Steps;
using MarsAdvanceTaskNUnit.Steps.LanguageSteps;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Tests
{
    [TestFixture, Order(5)]
    public class LanguagesTest : BaseSetUp.BaseSetUp
    {
        SignInSteps SignInStepsObj;
        ActionOnLanguageComponentSteps ActionOnLanguageStepsObj;
        ProfileLanguageOverviewComponentSteps ProfileLanguageOverviewStepsObj;

        public LanguagesTest()
        {
            SignInStepsObj = new SignInSteps();
            ActionOnLanguageStepsObj = new ActionOnLanguageComponentSteps();
            ProfileLanguageOverviewStepsObj = new ProfileLanguageOverviewComponentSteps();
        }

        [Test, Order(2)]
        public void AddLanguage_Test()
        {
            //------Adding a language------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddLanguage.json");
                //Deleting langauge record 
                foreach (var language in languageList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                }
                //Adding langauge 
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddLanguage"), "Add language successful");
                    ProfileLanguageOverviewStepsObj.ValidateLanguageAdded(language);
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddLanguage"), "Exception in Add language");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(3)]
        public void DeleteLanguage_Test()
        {
            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<LanguageModel> languageToDeleteList = JsonReader.GetData<LanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\DeleteLanguage.json");

                //Adding langauge for deletion
                foreach (var language in languageToDeleteList)
                {
                    ActionOnLanguageStepsObj.AddLanguage(language);
                }

                //Deleting langauge record 
                foreach (var language in languageToDeleteList)
                {
                    ProfileLanguageOverviewStepsObj.DeleteLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteLanguage"), "Delete language successful");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteLanguage"), "Exception in Delete language");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(4)]
        public void UpdateLanguage_Test()
        {
            //------Update a language------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<UpdateLanguageModel> languageToUpdateList = JsonReader.GetData<UpdateLanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\UpdateLanguage.json");

                //Updating langauge         
                foreach (var language in languageToUpdateList)
                {
                    ActionOnLanguageStepsObj.UpdateLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateLanguage"), "Update language successful");
                    ProfileLanguageOverviewStepsObj.ValidateLanguageUpdated(language);
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "DeleteLanguage"), "Exception in Delete language");
                test.Fail(ex.Message);
            }
        }

        [Test, Order(1)]
        public void CancelLanguageAddition_Test()
        {
            //------Cancel adding a language------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\CancelAddLanguage.json");

                //Adding langauge to cancel
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.CancelAddLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelLanguageAddition"), "Cancel Add language successful");
                    ProfileLanguageOverviewStepsObj.ValidateLanguageNotAdded(language);
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelLanguageAddition"), "Exception in Cancel Add language");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(5)]
        public void AddDuplicateLanguage_Test()
        {
            //----Add duplicated language------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddDuplicateLanguage.json");

                //Adding duplicate langauge record 
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddDuplicateLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDuplicateLanguage"), "Add duplicate language successful");
                    ProfileLanguageOverviewStepsObj.ValidateLanguageNotAdded(language);
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddDuplicateLanguage"), "Exception in add duplicate language");
                test.Fail(ex.Message);
            }

        }
        [Test, Order(6)]
        public void AddInvalidLanguage_Test()
        {
            //------Adding an invalid language------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<LanguageModel> languageList = JsonReader.GetData<LanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\AddInvalidLanguage.json");

                //Adding invalid langauge record 
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.AddInvalidLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidLanguage"), "Add invalid language successful");
                    ProfileLanguageOverviewStepsObj.ValidateLanguageNotAdded(language);
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "AddInvalidLanguage"), "Exception in add invalid language");
                test.Fail(ex.Message);
            }

        }

        [Test, Order(7)]
        public void UpdateInvalidLanguage_Test()
        {
            //------Updating an invalid language------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\UpdateInvalidLanguage.json");

                //Update invalid langauge record 
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.UpdateInvalidLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidLanguage"), "Update invalid language successful");
                    ProfileLanguageOverviewStepsObj.ValidateLanguageNotUpdated(language);
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "UpdateInvalidLanguage"), "Exception in Update invalid language");
                test.Fail(ex.Message);
            }
        }
        [Test, Order(8)]
        public void CancelUpdateLanguage_Test()
        {
            //------Cancel updating a language------
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                SignInStepsObj.SignIn();
                List<UpdateLanguageModel> languageList = JsonReader.GetData<UpdateLanguageModel>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\CancelUpdateLanguage.json");

                //Update invalid langauge record 
                foreach (var language in languageList)
                {
                    ActionOnLanguageStepsObj.CancelUpdateLanguage(language);
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelUpdateLanguage"), "Cancel update language successful");
                    ProfileLanguageOverviewStepsObj.ValidateLanguageNotUpdated(language);
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "CancelUpdateLanguage"), "Exception in cancel update invalid language");
                test.Fail(ex.Message);
            }
        }
    }
}
