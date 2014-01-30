using Guardian.TestLogic;
using Guardian.UserDefined;
using System;
using TechTalk.SpecFlow;

namespace Guardian.BDD
{
    [Binding]
    public class GuardianWebsiteUserSteps:GuardianTestLogic
    {
        [Given(@"Guardian Website")]
public void GivenGuardianWebsite()
{
    SelectBrowser("Chrome");
    GoToGuardianHome();
    GoToLink(GlobalFunction.SignIn);
    PopupHandler(); //Unable to handle Iframe within the Timeline for this challenge, 
    GoToGuardianCreateNewUser(); //So triggered "Register for the Guardian Page" URL directly
}

        [When(@"When I Register a New User")]
public void WhenWhenIRegisterANewUser()
{
    VerifyRegisterPage();
    RegisterNewUser(GlobalFunction.UserNameData, GlobalFunction.EmailData, GlobalFunction.PasswordData);
    VerifyCompletePage();
}

        [When(@"I Login as Guest User")]
public void WhenILoginAsGuestUser()
{
    VerifyRegisterPage();
    GuestUserNavigation("Twitter");
}

        [Then(@"I see New User on Guardian Home Page")]
public void ThenISeeNewUserOnGuardianHomePage()
{
    VerifyNewAccount(GlobalFunction.UserNameData);
}

        [Then(@"I see Guardian Home Page as a Guest User")]
public void ThenISeeGuardianHomePageAsAGuestUser()
{
    GuestTwitter(GlobalFunction.TwitterUserName, GlobalFunction.TwitterPassword);
}
    }
}
