using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages;
using MarsAdvanceTaskNUnit.Pages.Components.DescriptionOverview;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Steps.DescriptionSteps
{
    public class DescriptionOverviewSteps
    {
        DescriptionOverviewComponent DescriptionOverviewComponentObj;
        public DescriptionOverviewSteps()
        {
            DescriptionOverviewComponentObj = new DescriptionOverviewComponent();
        }
        public void ValidateDesciption(DescriptionModel description)
        {
            try
            {

                //--------Verify the description added.--------
                string newAddedDescription = DescriptionOverviewComponentObj.GetAddedUpdatedDescription();
                Assert.AreEqual(description.description, newAddedDescription, "Actual and expected message do not match. Description not added!!");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }

    }
}

