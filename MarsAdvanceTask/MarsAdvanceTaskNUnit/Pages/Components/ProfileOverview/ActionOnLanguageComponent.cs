﻿using MarsAdvanceTaskNUnit.Model;
using MarsAdvanceTaskNUnit.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskNUnit.Pages.Components.ProfileOverview
{
    public class ActionOnLanguageComponent : CommonDriver
    {
        private IWebElement addButton;
        private IWebElement updateButton;
        private IWebElement cancelButton;
        private IWebElement languageTextBox;
        private IWebElement languageLevelDropDown;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;
        public void RenderAddComponents()
        {
            //------Render component------
            try
            {
                addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
                languageTextBox = driver.FindElement(By.XPath("//*[@placeholder='Add Language']"));
                languageLevelDropDown = driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderUpdateComponents()
        {
            //------Render update component------
            try
            {
                updateButton = driver.FindElement(By.XPath("//*[@value='Update']"));
                cancelButton = driver.FindElement(By.XPath("//*[@value='Cancel']"));
                languageTextBox = driver.FindElement(By.XPath("//*[@placeholder='Add Language']"));
                languageLevelDropDown = driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RenderMessage()
        {
            //------Render message component------
            try
            {
                messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddLanguage(LanguageModel language)
        {
            //------Adding a language-------
            Wait.WaitToExist(driver, "XPath", "//*[@placeholder='Add Language']", 4);
            RenderAddComponents();

            //Enter record details
            languageTextBox.SendKeys(language.language);
            SelectElement languageLevelOption = new SelectElement(languageLevelDropDown);
            languageLevelOption.SelectByText(language.level);

            //Click on "Add" button.
            addButton.Click();
        }
        public void UpdateLanguage(UpdateLanguageModel language)
        {
            //-----updating a language------------

            Wait.WaitToExist(driver, "XPath", "//*[@placeholder='Add Language']", 5);
            RenderUpdateComponents();

            //Enter record details
            languageTextBox.SendKeys(Keys.Control + "A");
            languageTextBox.SendKeys(Keys.Backspace);
            languageTextBox.SendKeys(language.language);
            SelectElement languageLevelOption = new SelectElement(languageLevelDropDown);
            languageLevelOption.SelectByText(language.level);
            //Click on "Update" button.            
            updateButton.Click();
        }
        public string GetMessage()
        {
            //--Returning error or success message--

            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 5);
            RenderMessage();

            string message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            closeMessageIcon.Click();
            if (message == "Please enter language and level")
            {
                // RenderAddComponents();
                cancelButton.Click();
            }
            return message;
        }
        public void CancelLanguageAddition(LanguageModel language)
        {
            //----Cancel adding a language-----------

            Wait.WaitToExist(driver, "XPath", "//*[@placeholder='Add Language']", 4);
            RenderAddComponents();

            //Enter record details
            languageTextBox.SendKeys(language.language);
            SelectElement languageLevelOption = new SelectElement(languageLevelDropDown);
            languageLevelOption.SelectByText(language.level);
            //Click on "Cancel" button
            cancelButton.Click();
        }
        public void CancelUpdateLanguage(UpdateLanguageModel language)
        {
            //-----Cancel updating a language------------

            Wait.WaitToExist(driver, "XPath", "//*[@placeholder='Add Language']", 5);
            RenderUpdateComponents();

            //Enter record details
            languageTextBox.SendKeys(Keys.Control + "A");
            languageTextBox.SendKeys(Keys.Backspace);
            languageTextBox.SendKeys(language.language);
            SelectElement languageLevelOption = new SelectElement(languageLevelDropDown);
            languageLevelOption.SelectByText(language.level);
            //Click on "Update" button.            
            cancelButton.Click();
        }
    }
}
