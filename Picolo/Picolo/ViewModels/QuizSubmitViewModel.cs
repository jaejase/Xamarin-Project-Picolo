using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Picolo.Models;
using Picolo.Views;
using Picolo.Services;
using MvvmHelpers;
using System.Threading.Tasks;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.ViewModels
{
    [QueryProperty("QuestionNum", "questionNum")]
    [QueryProperty("Selection1", "selection1")]
    [QueryProperty("Selection2", "selection2")]
    [QueryProperty("Selection3", "selection3")]
    [QueryProperty("Selection4", "selection4")]
    class QuizSubmitViewModel : BaseViewModel
    {
        public Command CloseQuestionCommand { get; }
        public Command SubmitCommand { get; }


        public QuizSubmitViewModel()
        {
            OnAppearing();
            Title = "Submit Quiz";
            CloseQuestionCommand = new Command(OnSwipeRight);
            SubmitCommand = new Command(OnSubmission);
        }

        protected async void OnAppearing()
        {
            await Task.Delay(1000);
        }
        // Close instance of QuestionPage.
        private async void OnSwipeRight(object obj)
        {
            // This will pop the current page off the navigation stack.
            // Forms.Shell makes the page disapear without an animation.
            ChangeQNum(false);
            await Shell.Current.GoToAsync($"..?questionNum={PassQuestionNum}&selection1={Selection1}&selection2={Selection2}&selection3={Selection3}&selection4={Selection4}");
        }
        public string HatUser1 { get; set; }
        public int PersonalExperience1 { get; set; }
        public int QuestionsAnswered1 { get; set; }
        public int QuestsCompleted1 { get; set; }

        private async void OnSubmission(object obj)
        {
            UpdateQuests();
            UpdateUser();

            await Shell.Current.GoToAsync($"{nameof(QuizSummaryPage)}?selection1={Selection1}&selection2={Selection2}&selection3={Selection3}&selection4={Selection4}");
        }

        public async void UpdateQuests()
        {
            var quiz1 = await QuestDataStore.GetItemAsync("quiz1");
            Quest quiz1Quest = new Quest
            {
                Id = "quiz1",
                Type = "quiz",
                Name = "Quiz 1 - Australian History",
                Topic = "History",
                Experience = 200,
                QuestDate = DateTime.Now,
                Status = "complete",
                QuestResult = 4,
                NumQuestions = 4,
            };
            await QuestDataStore.UpdateItemAsync(quiz1Quest);
        }
        public async void UpdateUser()
        {
            var user1 = await UserDataStore.GetItemAsync("User1");
            HatUser1 = user1.HatColour;
            PersonalExperience1 = user1.PersonalExperience;
            QuestionsAnswered1 = user1.QuestionsAnswered;
            QuestsCompleted1 = user1.QuestsCompleted;
            User newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User1",
                Username = "wHoaMI",
                Password = null,
                PersonalExperience = PersonalExperience1 + 200,
                PartyExperience = 2100,
                HatColour = HatUser1,

                //statistics
                QuestionsAnswered = QuestionsAnswered1 + 4,
                QuestsCompleted = QuestsCompleted1 + 1,
                CommentsPosted = 3,
                AverageQuizAccuracy = 99,
                AverageTimeTakenEachActivity = 23,

                //trophygained
                Trophy1Gained = false,
                Trophy2Gained = true,
                Trophy3Gained = true,
                Trophy4Gained = true,
                Trophy5Gained = true,
                Trophy6Gained = user1.Trophy6Gained,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false
            };
            await UserDataStore.UpdateItemAsync(newUser);
        }

        /// Change the value of PassQuestionNum and update the string QuestionNum.
        /// Use true arg for addition and false arg for subtraction.
        public void ChangeQNum(bool addition)
        {
            if (addition == true)
            {
                passQuestionNum = Int32.Parse(QuestionNum);
                passQuestionNum++;
                questionNum = PassQuestionNum.ToString();
            }
            else
            {
                passQuestionNum = Int32.Parse(QuestionNum);
                passQuestionNum--;
                questionNum = PassQuestionNum.ToString();
            }
        }

        // The time limit for the quiz
        string questionNum;

        public string QuestionNum
        {
            get => questionNum;
            set
            {
                SetProperty(ref questionNum, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(QuestionNum));
                OnPropertyChanged(nameof(QuestionTitle));
            }
        }

        public string QuestionTitle => $"Question {QuestionNum}";
        // Make a variable that can pass the question number as an int.
        int passQuestionNum;
        public int PassQuestionNum
        {
            get => passQuestionNum;
            set
            {
                SetProperty(ref passQuestionNum, value);
            }
        }

        // Collection of variables that get passed to indicate what answers are selected.
        // 0 indicates no selection.
        string selection1 = "0";

        public string Selection1
        {
            get => selection1;
            set
            {
                SetProperty(ref selection1, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Selection1));
            }
        }

        string selection2 = "0";
        public string Selection2
        {
            get => selection2;
            set
            {
                SetProperty(ref selection2, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Selection2));
            }
        }

        string selection3 = "0";
        public string Selection3
        {
            get => selection3;
            set
            {
                SetProperty(ref selection3, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Selection3));
            }
        }

        string selection4 = "0";
        public string Selection4
        {
            get => selection4;
            set
            {
                SetProperty(ref selection4, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Selection4));
            }
        }

    } // End QuizSubmitViewModel
}
