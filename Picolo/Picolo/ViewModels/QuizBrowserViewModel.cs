using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using MvvmHelpers;
using Picolo.Views;
using Picolo.Services;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Picolo.Models;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.ViewModels
{
    
    public class QuizBrowserViewModel : BaseViewModel
    {
        // Button command
        public Command QuizLobbyCommand { get; }
        // Probably not needed
        //bool isLoaded;

        
        public QuizBrowserViewModel()
        {
            Title = "QuizBrowser";
            QuizLobbyCommand = new Command(OnQuizLobbyClicked);
            //this.BindingContext = new QuizDataStore();
        }

        // Define the AusHistory object.
        public Quiz AusHistory = new Quiz();
        protected async void OnAppearing()
        {
            // Get the AusHistory data from the database.            
            AusHistory = await QuizDataStore.GetItemAsync("Q1");
            browserButton1 = AusHistory.QuizID;
            // Not used may be unnecessary.
            //if (!isLoaded)
            //{
            //    // text = quiz.text
            //    //Quests.Clear();
            //    //var quests = await QuizDataStore.GetItemsAsync(true);
            //    //foreach (var quest in quests)
            //    //{
            //    //    Quiz.Add(quest);
            //    //}

            //    isLoaded = true;
            //}

        } // End OnAppearing

        // Bound object that is called in the view.
        // Hard coded because of database bugs.
        string browserButton1 = "Australian History";
        
       
        public string BrowserButton1
        {
            get => browserButton1;
            set
            {
                SetProperty(ref browserButton1, value);
                OnPropertyChanged(nameof(BrowserButton1));
            }
        }


        //private void SetProperty(ref string browserButton1, object quiz)
        //{
        //    throw new NotImplementedException();
        //}

        // Variable to track which question we are looking at.
        //public int QuestionNum = 0;
        private async void OnQuizLobbyClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(QuizLobbyPage)}");
        }


    }

}
