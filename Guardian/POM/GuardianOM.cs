using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.POM
{
    public class GuardianOM:GuardianOR
    {
        public IWebDriver webDriver;
        GuardianOR guardianOR = new GuardianOR();

        public bool IsElementPresent(By by)
        {
            try
            {
                webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public IWebElement ElementByLinkText(string LINKTEXT)
        {
            try
            {
                return webDriver.FindElement(By.LinkText(LINKTEXT));

            }
            catch (NoSuchElementException)
            {

                throw;
            }
        }
        public IWebElement ElementByPartialLinkText(string LINKTEXT)
        {
            try
            {
                return webDriver.FindElement(By.PartialLinkText(LINKTEXT));

            }
            catch (NoSuchElementException)
            {

                throw;
            }
        }
        public IWebElement ElementByID(string ID)
        {
            try
            {
                return webDriver.FindElement(By.Id(ID));

            }
            catch (NoSuchElementException)
            {

                throw;
            }
        }
        public IWebElement ElementByXPath(string XPATH)
        {
            try
            {
                return webDriver.FindElement(By.XPath(XPATH));

            }
            catch (NoSuchElementException)
            {

                throw;
            }
        }
        public IWebElement ElementByClass(string CLASS)
        {
            try
            {
                return webDriver.FindElement(By.ClassName(CLASS));

            }
            catch (NoSuchElementException)
            {

                throw;
            }
        }

        public void GoToLinkText(string LinkText)
        {
            webDriver.FindElement(By.LinkText(LinkText));
        }



    
    }
}
