using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.TestLogic
{
    interface IGuardianTestLogic
    {
        void SelectBrowser(string Browser);
        void GoToGuardianHome();
        void GoToGuardianCreateNewUser();
        void RegisterNewUser(string UserName, string Email, string Password);
        void VerifyRegisterPage();       
        void VerifyNewAccount(string NewUser);
        void VerifyCompletePage();
        void GoToLink(string LinkName);
        void SignOut(string CurrentUser);
        void PopupHandler();

        void NegativeBlankDetails();
        void NegativeInvalidDetails();
        void NegativeRegisterNoTermsConditions(string UserName, string Email, string Password);
        void NegativeTermsConditions();

        void GuestUserNavigation(string Guest);
        void GuestTwitter(string UserName, string Password);
        void GuestFacebook();
        void GuestGoogle();

        void VerifyLinkPage(string LINK);
        void RandomNavigation();
    }
}
