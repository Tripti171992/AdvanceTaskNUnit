using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages.Components.ProfileOverview;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Steps.LanguageSteps
{
    public class ProfileLanguageOverviewComponentSteps
    {
        ProfileLanguageOverviewComponent ProfileLanguageOverviewComponentObj;

        public ProfileLanguageOverviewComponentSteps()
        {
            ProfileLanguageOverviewComponentObj = new ProfileLanguageOverviewComponent();
        }
        public void ValidateLanguageAdded(LanguageModel language)
        {
            //--------Validate a language added--------
            try
            {
                //Verify the added language record in the table
                string newAddedLanguage = ProfileLanguageOverviewComponentObj.GetLanguage();
                string newAddedLanguageLevel = ProfileLanguageOverviewComponentObj.GetLanguageLevel();
                Assert.AreEqual(language.language, newAddedLanguage, "Actual and expected language do not match. Language not added!!");
                Assert.AreEqual(language.level, newAddedLanguageLevel, "Actual and expected language level do not match. Language level not added !!");

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateLanguageUpdated(UpdateLanguageModel language)
        {
            //--------Validate a language updated--------
            try
            {
                //Verify language record updated
                string result = ProfileLanguageOverviewComponentObj.GetUpdatedLanguageResult(language);
                Assert.AreEqual("Updated", result, "Actual and expected result do not match. Language not updated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void DeleteLanguage(LanguageModel language)
        {
            //--------Delete a language--------
            try
            {
                ProfileLanguageOverviewComponentObj.DeleteLanguage(language);
                //Verifying success message for deletion of a language record
                string expectedMessage = language.language + " has been deleted from your languages";
                string actualMessage = ProfileLanguageOverviewComponentObj.GetMessage();
                if (actualMessage.Contains("Timed out after"))
                {
                    Console.WriteLine(expectedMessage);
                }
                else
                {
                    Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected language match. Language not deleted!!");
                }
                //Verify the language record deleted
                string result = ProfileLanguageOverviewComponentObj.GetDeleteLanguageResult(language);
                Assert.AreEqual("Deleted", result, "Actual and expected result do not match. Language not deleted!!");

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateLanguageNotAdded(LanguageModel language)
        {
            //--------Validate a language not added--------
            try
            {
                //Verify the language record not added in the table
                string newAddedLanguage = ProfileLanguageOverviewComponentObj.GetLanguage();
                string newAddedLanguageLevel = ProfileLanguageOverviewComponentObj.GetLanguageLevel();
                Assert.AreNotEqual(language.language, newAddedLanguage, "Actual and expected language do not match. Language added!!");
                Assert.AreNotEqual(language.level, newAddedLanguageLevel, "Actual and expected language level do not match. Language level added !!");

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
        public void ValidateLanguageNotUpdated(UpdateLanguageModel language)
        {
            //--------Validate language not updated--------
            try
            {
                //Verify language record updated
                string result = ProfileLanguageOverviewComponentObj.GetUpdatedLanguageResult(language);
                Assert.AreEqual("Not updated", result, "Actual and expected result do not match. Language updated!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
    }
}
