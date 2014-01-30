using Guardian.TestLogic;
using Guardian.UserDefined;
using System;
using TechTalk.SpecFlow;

namespace Guardian
{
    [Binding]
    public class NegativeTestsSteps:GuardianTestLogic
    {
        [Given(@"Guardian Site")]
        public void GivenGuardianSite()
        {
            SelectBrowser("Chrome");
            GoToGuardianHome();
            GoToLink(GlobalFunction.SignIn);
            PopupHandler(); //Unable to handle Iframe within the Timeline for this challenge, 
            GoToGuardianCreateNewUser(); //So triggered "Register for the Guardian Page" URL directly
        }
       
        [When(@"I Register a Blank User")]
public void WhenIRegisterABlankUser()
{
    VerifyRegisterPage();
    RegisterNewUser("", "", "");
}

        [When(@"I Register User with Invalid User Data")]
public void WhenIRegisterUserWithInvalidUserData()
{
    VerifyRegisterPage();
    RegisterNewUser("test", "test", "test");
}

        [When(@"I Register User with Incomplete Registration Details")]
public void WhenIRegisterUserWithIncompleteRegistrationDetails()
{
    VerifyRegisterPage();
    NegativeRegisterNoTermsConditions(GlobalFunction.nUserNameData, GlobalFunction.nEmailData, GlobalFunction.nPasswordData);
}

        [Then(@"Required Field Error Message is returned")]
public void ThenRequiredFieldErrorMessageIsReturned()
{
    VerifyRegisterPage();
    NegativeBlankDetails();
}

        [Then(@"Invalid Error Message is returned")]
public void ThenInvalidErrorMessageIsReturned()
{
    VerifyRegisterPage();
    NegativeInvalidDetails();
}

        [Then(@"Mandatory Requirement Error Message is returned")]
public void ThenMandatoryRequirementErrorMessageIsReturned()
{
    VerifyRegisterPage();
    NegativeTermsConditions();
}
    }
}
