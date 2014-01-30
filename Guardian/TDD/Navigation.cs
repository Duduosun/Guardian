using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guardian.TestLogic;

namespace Guardian.TDD
{
    [TestClass]
    public class Navigation:GuardianTestLogic
    {
       [TestInitialize]
        public void TestSetup()
        {
            SelectBrowser("Chrome");
            GoToGuardianHome();
        }

       [TestMethod]
       [Priority(0)]
       public void JustLinksNavigation()
       {
           VerifyLinkPage("Tech");
           VerifyLinkPage("Sport");
           VerifyLinkPage("Comment");
           VerifyLinkPage("Culture");
           VerifyLinkPage("Business");
           VerifyLinkPage("Money");
           VerifyLinkPage("Travel");
           VerifyLinkPage("Environment");
           VerifyLinkPage("Tech");
           VerifyLinkPage("TV");
       }

       [TestMethod]
       [Priority(1)]
       public void StoryNavigation()
       {
           RandomNavigation();
       }

    }
}
