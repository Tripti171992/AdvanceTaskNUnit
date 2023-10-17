using MarsAdvanceTaskNUnit.Pages;
using MarsAdvanceTaskNUnit.Utilities;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Steps;
using MarsAdvanceTaskNUnit.Pages.Components.SignInOverview;
using AventStack.ExtentReports.Reporter.Config;

namespace MarsAdvanceTaskNUnit.BaseSetUp
{
    [TestFixture]
    public class BaseSetUp : CommonDriver
    {
        SplashPage SplashPageComponentObj;
        SignInComponent SigninComponentObj;
        public ExtentReports extent;
        public ExtentTest test;
        public BaseSetUp()
        {
            SplashPageComponentObj = new SplashPage();
            SigninComponentObj = new SignInComponent();
        }
        [OneTimeSetUp]
        public void TestSuitSetUp()
        {
            ExtentSparkReporter htmlReport = new ExtentSparkReporter(ConstantUtils.ReportsPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReport);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Tripti");

            htmlReport.Config.DocumentTitle = "Automation Report";
            htmlReport.Config.ReportName = "Test Report";
            htmlReport.Config.Theme = Theme.Dark;
        }

        [SetUp]
        public virtual void SetActions()
        {
            Initialize();
            NavigateUrl();
        }

        [TearDown]
        public void TearDownActions()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Passed)
            {
                test.Pass("Test Case Passed!!");
            }
            else if (status == TestStatus.Failed)
            {
                test.Fail("Test Case Failed!!");

            }
            Close();
        }

        [OneTimeTearDown]
        public void TestSuitTearDown()
        {
            extent.Flush();
        }
    }
}
