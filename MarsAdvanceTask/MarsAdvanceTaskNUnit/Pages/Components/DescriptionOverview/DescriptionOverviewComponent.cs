﻿using MarsAdvanceTaskNUnit.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Pages.Components.DescriptionOverview
{
    public class DescriptionOverviewComponent : CommonDriver
    {
        private IWebElement descriptionWriteIcon;
        private IWebElement savedDescription;
        public void RenderComponents()
        {
            //------Render component------
            try
            {
                descriptionWriteIcon = driver.FindElement(By.XPath("//*[text()='Description']//i"));
                savedDescription = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickDescriptionWriteIcon()
        {
            //------Click on WriteIcon button------
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Description']//i", 6);

            RenderComponents();

            descriptionWriteIcon.Click();
        }
        public string GetAddedUpdatedDescription()
        {
            //------Return new added/Updated description------
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span", 4);
            RenderComponents();

            return savedDescription.Text;

        }
    }
}
