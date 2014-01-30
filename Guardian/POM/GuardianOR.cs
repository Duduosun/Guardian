using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardian.POM
{
    public class GuardianOR
    {
        //Urls
        public string baseURL = "http://www.guardian.co.uk";
        public string regURL = "https://id.theguardian.com/register?returnUrl=http%3A%2F%2Fwww.theguardian.com%2Fuk";

        //Page Titles
        public string HomePageTitle = "Latest news, sport and comment from the Guardian | The Guardian";
        public string RegisterPageTitle = "Register for the Guardian";
        public string RegCompletePageTitle = "Registration complete on the Guardian";
        public string AuthoriseTwitterPageTitle = "Twitter / Authorise an application";
        public string AuthoriseFacebookPageTitle = "Facebook";
        public string AuthoriseGooglePageTitle = "Sign in - Google Accounts";


        //Control Objects
        public string idUserName = "username";
        public string idEmail = "email";
        public string idNewPassword = "password";
        public string idRepeatPassword = "password-again";
        public string idAcceptTerms = "accept-terms";
        public string idContinue = "Continue";
        public string idTwitterUsername = "username_or_email";
        public string idTwitterPassword = "session[password]";
        public string idTwitterSubmit = "allow";
        

        //XPath
        public string xHighlightedNewsLink = "/html/body/div[2]/div[2]/div[2]/span/div/div/ul/li/div/h3/a";
        public string xLeftsideNewsLink = "/html/body/div[2]/div[2]/div/span/div/div/ul/li/h1/a";
        public string xContinue = "/html/body/div/div[2]/form/fieldset/div[8]/input[2]";
        public string xRegContinue = "/html/body/div/div/form/p/a";
        public string xCurrentUser = "/html/body/div[2]/div/div/div/div[4]/div/h2";
        public string xUserNameToolTip = "/html/body/div/div[2]/form/fieldset/div[1]/div[2]";
        public string xEmailToolTip = "/html/body/div/div[2]/form/fieldset/div[2]/div[2]";
        public string xNewPasswordToolTip = "/html/body/div/div[2]/form/fieldset/div[3]/div[4]";
        public string xRepeatPasswordToolTip = "/html/body/div/div[2]/form/fieldset/div[4]/div";
        public string xAcceptTerms = "/html/body/div/div[2]/form/fieldset/div[7]/div";

        //Class
        public string clSignInFrame = "identity-overlay-inner";
        public string clToolTipError = "tooltip tooltipHide error";

    }
}
