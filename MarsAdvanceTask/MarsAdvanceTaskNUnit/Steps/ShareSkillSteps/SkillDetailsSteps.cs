using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Pages.Components.ProfileOverview;
using MarsAdvanceTaskNUnit.Pages.Components.ShareSkillOverview;
using MarsAdvanceTaskNUnit.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvanceTaskNUnit.Pages.Components.SkillDetails;

namespace MarsAdvanceTaskNUnit.Steps.ShareSkillSteps
{
    public class SkillDetailsSteps
    {
        SkillDetailsComponent SkillDetailsComponentObj;
        public SkillDetailsSteps()
        {
            SkillDetailsComponentObj = new SkillDetailsComponent();
        }
        public void ValidateSkillTitle(SkillModel skill)
        {
            //--------Validate a skill title---
            try
            {
                //Verify the title of the page  
                string expectedTitle = skill.title;
                string actualTitel = SkillDetailsComponentObj.GetSkillTitle();
                Assert.AreEqual(expectedTitle, actualTitel, "Actual and expected title do not match.");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
    }
}
