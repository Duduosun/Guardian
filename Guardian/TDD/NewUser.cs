using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guardian.TestLogic;
using Guardian.UserDefined;

namespace Guardian
{
    [TestClass]
    public class NewUser:GuardianTestLogic
    {
        [TestInitialize]
        public void TestSetup()
        {
            SelectBrowser("Chrome");
            GoToGuardianHome();
            GoToLink(GlobalFunction.SignIn);
            PopupHandler(); //Unable to handle Iframe within the Timeline for this challenge, 
            GoToGuardianCreateNewUser(); //So triggered "Register for the Guardian Page" URL directly
        }
        [TestMethod]
        [Priority(0)]
        public void RegisterUser()
        {
            VerifyRegisterPage();
            RegisterNewUser(GlobalFunction.UserNameData, GlobalFunction.EmailData, GlobalFunction.PasswordData);
            VerifyCompletePage();
            VerifyNewAccount(GlobalFunction.UserNameData);
        }

        [TestMethod]
        [Priority(1)]
        public void RegisterBlankUser()
        {
            VerifyRegisterPage();
            RegisterNewUser("", "", "");
            VerifyRegisterPage();
            NegativeBlankDetails();
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterInvalidUserData()
        {
            VerifyRegisterPage();
            RegisterNewUser("test", "test", "test");
            VerifyRegisterPage();
            NegativeInvalidDetails();
        }

        [TestMethod]
        [Priority(3)]
        public void IncompleteRegistration()
        {
            VerifyRegisterPage();
            NegativeRegisterNoTermsConditions(GlobalFunction.nUserNameData, GlobalFunction.nEmailData, GlobalFunction.nPasswordData);
            VerifyRegisterPage();
            NegativeTermsConditions();
        }

        [TestMethod]
        [Priority(4)]
        public void GuestUser()
        {
            VerifyRegisterPage();
            GuestUserNavigation("Twitter");
            GuestTwitter(GlobalFunction.TwitterUserName, GlobalFunction.TwitterPassword);
        }

        [TestCleanup]
        public void UnloadDriver()
        {
        }
    }
}
