using System;
using System.Collections.Generic;
using Picolo.ViewModels;
using Picolo.Views;
using Xamarin.Forms;

namespace Picolo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QuestSummary), typeof(QuestSummary));
            Routing.RegisterRoute(nameof(QuestLog), typeof(QuestLog));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));

            //Routing for the quiz pages. Note that Sri has a more compact way of doing this in 
            //the week 9 lecture.
            Routing.RegisterRoute(nameof(QuizLobbyPage), typeof(QuizLobbyPage));
            Routing.RegisterRoute(nameof(QuestionPage), typeof(QuestionPage));
            Routing.RegisterRoute(nameof(QuizBrowserPage), typeof(QuizBrowserPage));
            Routing.RegisterRoute(nameof(QuizSubmitPage), typeof(QuizSubmitPage));
            Routing.RegisterRoute(nameof(QuizSummaryPage), typeof(QuizSummaryPage));
            //Routing for group functions
            Routing.RegisterRoute(nameof(HatQuiz), typeof(HatQuiz));
            Routing.RegisterRoute(nameof(HatQuizQuestion), typeof(HatQuizQuestion));
            Routing.RegisterRoute(nameof(HatQuizResult), typeof(HatQuizResult));
            Routing.RegisterRoute(nameof(PartySelection), typeof(PartySelection));
            Routing.RegisterRoute(nameof(PartyView), typeof(PartyView));
            //Routing for settings page
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(ThemeSelectionPage), typeof(ThemeSelectionPage));
            //Routing for login page
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
        }

    }
}
