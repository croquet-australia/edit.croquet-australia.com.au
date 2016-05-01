using System;
using CroquetAustralia.Edit.Specifications.Helpers;
using TechTalk.SpecFlow;

namespace CroquetAustralia.Edit.Specifications.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly EditWebsite _editWebsite;

        public HomePageSteps(EditWebsite editWebsite)
        {
            _editWebsite = editWebsite;
        }

        [Given(@"the website is running")]
        public void GivenTheWebsiteIsRunning()
        {
            _editWebsite.StartIfNotRunning();
        }

        [Given(@"this is my first visit to the website")]
        public void GivenThisIsMyFirstVisitToTheWebsite()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [Given(@"I have a Google account")]
        public void GivenIHaveAGoogleAccount()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [Given(@"I am an authorised editor")]
        public void GivenIAmAnAuthorisedEditor()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [Given(@"I have signed in")]
        public void GivenIHaveSignedIn()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [When(@"I go to the home page")]
        public void WhenIGoToTheHomePage()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [When(@"I complete the Google sign in page")]
        public void WhenICompleteTheGoogleSignInPage()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [Then(@"I should see the Google sign in page")]
        public void ThenIShouldSeeTheGoogleSignInPage()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [Then(@"I should see the editor home page")]
        public void ThenIShouldSeeTheEditorHomePage()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }

        [Then(@"I should see the unauthorised page")]
        public void ThenIShouldSeeTheUnauthorisedPage()
        {
            throw new NotImplementedException("todo: Step not implemented");
        }
    }
}