using Guardian.POM;
using Guardian.UserDefined;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.TestLogic
{
    public class GuardianTestLogic:IGuardianTestLogic
    {
        GuardianOM guardianOM = new GuardianOM();
        public void SelectBrowser(string Browser)
        {
            if (Browser == "Firefox")
                guardianOM.webDriver = new FirefoxDriver();
            else if (Browser == "Chrome")
                guardianOM.webDriver = new ChromeDriver();
            else if (Browser == "IE")
                guardianOM.webDriver = new InternetExplorerDriver();
        }

        public void GoToGuardianHome()
        {
            guardianOM.webDriver.Navigate().GoToUrl(guardianOM.baseURL);
            guardianOM.webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.HomePageTitle));
        }

        public void GoToGuardianCreateNewUser()
        {
            guardianOM.webDriver.Navigate().GoToUrl(guardianOM.regURL);
            guardianOM.webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.RegisterPageTitle));
        }

        public void RegisterNewUser(string UserName, string Email, string Password)
        {
            if (guardianOM.ElementByID(guardianOM.idUserName).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idUserName).SendKeys(UserName);
            }
            if (guardianOM.ElementByID(guardianOM.idEmail).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idEmail).SendKeys(Email);
            }
            if (guardianOM.ElementByID(guardianOM.idNewPassword).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idNewPassword).SendKeys(Password);
            }
            if (guardianOM.ElementByID(guardianOM.idRepeatPassword).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idRepeatPassword).SendKeys(Password);
            }
            if (!guardianOM.ElementByID(guardianOM.idAcceptTerms).Selected)
            {
                guardianOM.ElementByID(guardianOM.idAcceptTerms).Click();
            }

            guardianOM.ElementByXPath(guardianOM.xContinue).Click();
        }

        public void VerifyRegisterPage()
        {
            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.RegisterPageTitle));

            Assert.IsTrue(guardianOM.ElementByPartialLinkText(GlobalFunction.Facebook).Enabled);
            Assert.IsTrue(guardianOM.ElementByPartialLinkText(GlobalFunction.Google).Enabled);
            Assert.IsTrue(guardianOM.ElementByPartialLinkText(GlobalFunction.Twitter).Enabled);

            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idUserName).Enabled);
            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idEmail).Enabled);
            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idNewPassword).Enabled);
            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idRepeatPassword).Enabled);
            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idAcceptTerms).Enabled);
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xContinue).Enabled);
        }

        public void VerifyCompletePage()
        {
            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.RegCompletePageTitle));
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xRegContinue).Enabled);

            if (guardianOM.ElementByXPath(guardianOM.xRegContinue).Enabled)
            {
                guardianOM.ElementByXPath(guardianOM.xRegContinue).Click();
            }
        }

        public void VerifyNewAccount(string NewUser)
        {
            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.HomePageTitle));
            Assert.IsTrue(guardianOM.ElementByLinkText(GlobalFunction.SignOut).Enabled);
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xCurrentUser).Enabled);
            Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xCurrentUser).Text, NewUser);
        }

        public void GoToLink(string LinkName)
        {
            if (guardianOM.ElementByLinkText(LinkName).Enabled)
            {
                guardianOM.ElementByLinkText(LinkName).Click();
            }
        }

        public void SignOut(string CurrentUser)
        {
            if (guardianOM.ElementByLinkText(GlobalFunction.SignOut).Enabled && guardianOM.ElementByLinkText(GlobalFunction.UserNameData).Enabled)
            {
                if (guardianOM.ElementByLinkText(GlobalFunction.UserNameData).Text.Equals(CurrentUser))
                {
                    guardianOM.ElementByLinkText(GlobalFunction.SignOut).Click();
                }
            }
            else
            {
                return;
            }
        }

        public void PopupHandler()
        {
            //IAlert alert = guardianOM.webDriver.SwitchTo().Alert();
            //alert.Accept();

            //TBC
            String parentWindowHandle = guardianOM.webDriver.CurrentWindowHandle; // save the current window handle.
            IWebDriver popup = null;
            var windowIterator = guardianOM.webDriver.WindowHandles;

            foreach (var windowHandle in windowIterator)
            {
                popup = guardianOM.webDriver.SwitchTo().Window(windowHandle);

                if (popup.Title == guardianOM.RegisterPageTitle)
                {
                    break;
                }
            }
        }


        public void NegativeBlankDetails()
        {
                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xUserNameToolTip).Enabled);
                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xUserNameToolTip).Displayed);
                Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xUserNameToolTip).Text, GlobalFunction.RequiredField);

                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xEmailToolTip).Enabled);
                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xEmailToolTip).Displayed);
                Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xEmailToolTip).Text, GlobalFunction.RequiredField);

                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xNewPasswordToolTip).Enabled);
                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xNewPasswordToolTip).Displayed);
                Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xNewPasswordToolTip).Text, GlobalFunction.RequiredField);

                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xRepeatPasswordToolTip).Enabled);
                Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xRepeatPasswordToolTip).Displayed);
                Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xRepeatPasswordToolTip).Text, GlobalFunction.RequiredField);                
        }

        public void NegativeInvalidDetails()
        {
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xUserNameToolTip).Enabled);
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xUserNameToolTip).Displayed);
            Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xUserNameToolTip).Text, GlobalFunction.InvalidUserName);

            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xEmailToolTip).Enabled);
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xEmailToolTip).Displayed);
            Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xEmailToolTip).Text, GlobalFunction.InvalidEmail);

            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xNewPasswordToolTip).Enabled);
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xNewPasswordToolTip).Displayed);
            Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xNewPasswordToolTip).Text, GlobalFunction.InvalidPassword);

            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xRepeatPasswordToolTip).Enabled);
            Assert.IsTrue(!guardianOM.ElementByXPath(guardianOM.xRepeatPasswordToolTip).Displayed);
        }

        public void NegativeRegisterNoTermsConditions(string UserName, string Email, string Password)
        {
            if (guardianOM.ElementByID(guardianOM.idUserName).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idUserName).SendKeys(UserName);
            }
            if (guardianOM.ElementByID(guardianOM.idEmail).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idEmail).SendKeys(Email);
            }
            if (guardianOM.ElementByID(guardianOM.idNewPassword).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idNewPassword).SendKeys(Password);
            }
            if (guardianOM.ElementByID(guardianOM.idRepeatPassword).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idRepeatPassword).SendKeys(Password);
            }
            if (!guardianOM.ElementByID(guardianOM.idAcceptTerms).Selected)
            {
                guardianOM.ElementByXPath(guardianOM.xContinue).Click();
            }
            else
            {
                guardianOM.ElementByID(guardianOM.idAcceptTerms).Click();
                guardianOM.ElementByXPath(guardianOM.xContinue).Click();
            }           
        }

        public void NegativeTermsConditions()
        {
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xAcceptTerms).Enabled);
            Assert.IsTrue(guardianOM.ElementByXPath(guardianOM.xAcceptTerms).Displayed);
            Assert.AreEqual(guardianOM.ElementByXPath(guardianOM.xAcceptTerms).Text, GlobalFunction.MustAcceptTermsConditions);
        }

        public void GuestUserNavigation(string Guest)
        {
            switch (Guest)
            {
                case "Facebook":
                    if (guardianOM.ElementByPartialLinkText(GlobalFunction.Facebook).Enabled)
                    {
                       guardianOM.ElementByPartialLinkText(GlobalFunction.Facebook).Click();
                    }
                    
                    break;

                case "Google+":
                    if (guardianOM.ElementByPartialLinkText(GlobalFunction.Google).Enabled)
                    {
                        guardianOM.ElementByPartialLinkText(GlobalFunction.Google).Click();
                    }

                    break;

                case "Twitter":
                    if (guardianOM.ElementByPartialLinkText(GlobalFunction.Twitter).Enabled)
                    {
                        guardianOM.ElementByPartialLinkText(GlobalFunction.Twitter).Click();
                    }
                    break;

                default:
                    Process.Start("notepad.exe");                
                    break;
            }
        }

        public void GuestTwitter(string UserName, string Password)
        {
            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.AuthoriseTwitterPageTitle));
            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idTwitterUsername).Enabled);
            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idNewPassword).Enabled);
            Assert.IsTrue(guardianOM.ElementByID(guardianOM.idTwitterSubmit).Enabled);

            if (guardianOM.ElementByID(guardianOM.idTwitterUsername).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idTwitterUsername).SendKeys(UserName);
            }

            if (guardianOM.ElementByID(guardianOM.idNewPassword).Enabled)
            {
                guardianOM.ElementByID(guardianOM.idNewPassword).SendKeys(Password);
            }

            guardianOM.ElementByID(guardianOM.idTwitterSubmit).Click();

            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.HomePageTitle));
            Assert.IsTrue(guardianOM.ElementByLinkText(GlobalFunction.SignIn).Enabled);
        }

        public void GuestFacebook()
        {
            throw new NotImplementedException();
        }

        public void GuestGoogle()
        {
            throw new NotImplementedException();
        }

        public void VerifyLinkPage(string LINK)
        {
            if (guardianOM.ElementByPartialLinkText(LINK).Enabled)
            {
                (guardianOM.ElementByPartialLinkText(LINK)).Click();
                Assert.IsTrue(guardianOM.webDriver.Title.Contains(LINK));
            }
        }

        public void RandomNavigation()
        {
            Assert.IsTrue(guardianOM.webDriver.Title.Equals(guardianOM.HomePageTitle));

            if (guardianOM.ElementByXPath(guardianOM.xHighlightedNewsLink).Enabled)
            {
                var LinkTextAlpha = guardianOM.ElementByXPath(guardianOM.xHighlightedNewsLink).Text;
                guardianOM.ElementByXPath(guardianOM.xHighlightedNewsLink).Click();
                Assert.IsTrue(guardianOM.webDriver.Title.ToString().Contains(LinkTextAlpha.ToString()));
            }

            GoToGuardianHome();

            if (guardianOM.ElementByXPath(guardianOM.xLeftsideNewsLink).Enabled)
            {
                var LinkTextBeta = guardianOM.ElementByXPath(guardianOM.xLeftsideNewsLink).Text;
                guardianOM.ElementByXPath(guardianOM.xLeftsideNewsLink).Click();
                Assert.IsTrue(guardianOM.webDriver.Title.ToString().Contains(LinkTextBeta.ToString()));
            }
        }
    }
}


