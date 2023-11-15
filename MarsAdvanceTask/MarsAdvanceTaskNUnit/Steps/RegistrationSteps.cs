using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages;
using MarsAdvanceTaskNUnit.Pages.Components.RegistrationOverview;
using MarsAdvanceTaskNUnit.Pages.Components.SignInOverview;
using MarsAdvanceTaskNUnit.Tests;
using MarsAdvanceTaskNUnit.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Steps
{
    public class RegistrationSteps
    {
        SplashPage SplashPageComponentObj;
        RegistrationComponent RegistrationComponentObj;
        public RegistrationSteps()
        {
            SplashPageComponentObj = new SplashPage();
            RegistrationComponentObj = new RegistrationComponent();
        }
        public void RegistrationInvalid(RegistrationModel user)
        {
            //------Invalid registration------
            try
            {
                SplashPageComponentObj.ClickJoinButton();
                RegistrationComponentObj.RegistrationInvalid(user);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        public void ValidateRegistrationInvalid()
        {
            //------Validate invalid registration------
            try
            {
                string message = RegistrationComponentObj.GetRegistrationMessage();
                Assert.AreNotEqual("Registration successful", message, "Actual and expected message do not match.User registered successfully !!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

    }
}
