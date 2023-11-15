using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages;
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
    public class SignInSteps
    {
        SplashPage SplashPageComponentObj;
        SignInComponent SigninComponentObj;
        public SignInSteps()
        {
            SplashPageComponentObj = new SplashPage();
            SigninComponentObj = new SignInComponent();
        }

        public void SignIn()
        {
            //------Sign in------
            SplashPageComponentObj.ClickSignInButton();
            //Login into Mars
            List<UserInformation> userList = JsonReader.GetData<UserInformation>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\AdvanceTaskNUnit\\AdvanceTaskNUnit\\MarsAdvanceTask\\MarsAdvanceTaskNUnit\\JsonObject\\UserInformation.json");
            SigninComponentObj.SignIn(userList[0]);
        }
        public void SignInInvalid(UserInformation user)
        {
            //------Invalid sign in------
            try
            {
                //Login into Mars
                SplashPageComponentObj.ClickSignInButton();
                SigninComponentObj.SignIn(user);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
