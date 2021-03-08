using System;
using System.Collections.ObjectModel;
//using System.Diagnostics;
//using System.Threading.Tasks;
using Xamarin.Forms;
//using Picolo.Models;
using Picolo.Views;
//using Picolo.Services;
using MvvmHelpers;
//using System.Runtime.CompilerServices;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.ViewModels
{
    class QuizLobbyViewModel : BaseViewModel
    {
        //Quiz AusHistory = new Quiz();
        public Command Quiz1Command { get; }
        // This is in the wrong place, keep until moved in full.
        //bool isLoaded;
        public QuizLobbyViewModel()
        {
            Title = "Quiz Lobby";
            Quiz1Command = new Command(OnQuiz1Clicked);

            
        } // End QuizLobbyViewModel.

        /// <summary>
        /// This would have been used to store and retrieve data from the database
        /// that didn't end up working.
        /// </summary>
        //protected async void OnAppearing()
        //{
        //    // Not implimented, didn't work.
        //    // Add the AusHistory data to the database.
        //    //await QuizDataStore.AddItemAsync(AusHistory);
        //    // Pull the files from QuizDataStore.            
        //    //AusHistory = await QuizDataStore.GetItemAsync("Q1");

        //} // End OnAppearing

        // Bound object that is called in the view.
        string lobbyTitle = "Australian History Quiz";

        public string LobbyTitle
        {
            get => lobbyTitle;
            set
            {
                SetProperty(ref lobbyTitle, value);
                OnPropertyChanged(nameof(LobbyTitle));
            }
        }

        // The number of questions in the quiz, it will display as a number not a
        // word if it is the number pulled from the database.
        string numberQ = "4";

        public string NumberQ
        {
            get => numberQ;
            set
            {
                SetProperty(ref numberQ, value);
                OnPropertyChanged(nameof(NumberQ));
                OnPropertyChanged(nameof(NumQuestions));
            }
        }

        public string NumQuestions => $"Number of questions: {NumberQ}.";

        // The time limit for the quiz
        string timeText = "(Time limits have not been implimented.)";

        public string TimeText
        {
            get => timeText;
            set
            {
                SetProperty(ref timeText, value);
                OnPropertyChanged(nameof(TimeText));
                OnPropertyChanged(nameof(TimeLimit));
            }
        }

        public string TimeLimit => $"Time limit: {TimeText}";


        // Variable to track which question we are looking at.
        /// <summary>
        /// Tracks wich question page we are looking at.
        /// </summary>
        public int QuestionNum = 1;
        /// <summary>
        /// Navigates to the first instance of the question page.
        /// </summary>
        /// <param name="obj"></param>
        private async void OnQuiz1Clicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(QuestionPage)}?questionNum={QuestionNum}");
        }

    } // QuizLobbyViewModel
}
