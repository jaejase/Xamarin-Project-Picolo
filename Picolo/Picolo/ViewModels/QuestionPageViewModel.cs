using System;
using System.Collections.Generic;
using System.Text;
using Picolo.Views;
using Xamarin.Forms;
using Picolo.Models;
using MvvmHelpers;
//using System.Security.Cryptography.X509Certificates;
//using System.Linq;
using System.Threading.Tasks;

namespace Picolo.ViewModels
{
    [QueryProperty("QuestionNum", "questionNum")]
    [QueryProperty("Selection1", "selection1")]
    [QueryProperty("Selection2", "selection2")]
    [QueryProperty("Selection3", "selection3")]
    [QueryProperty("Selection4", "selection4")]

    class QuestionPageViewModel : BaseViewModel
    {
        public Command Quiz1Command { get; }
        public Command CloseQuestionCommand { get; }
        public Command OptionsCommand { get; }
        public QuestionPageViewModel()
        {
            OnAppearing();
            Title = "QuestionPage";
            Quiz1Command = new Command(OnQuiz1Clicked);
            CloseQuestionCommand = new Command(OnSwipeRight);
            OptionsCommand = new Command(OnOptionSelected);
        }

        protected async void OnAppearing()
        {
            // Do something on startup.
            await Task.Delay(30);
            RadioSet(QuestionNum);
            // Put in its own method. Will cause bugs if code is accidentally put under this.
            if (QuestionNum == "1")
            {
                
                description = Question1.Text;
                OnPropertyChanged(nameof(Description));
                answer1 = Question1.A1;
                OnPropertyChanged(nameof(Answer1));
                answer2 = Question1.A2;
                OnPropertyChanged(nameof(Answer2));
                answer3 = Question1.A3;
                OnPropertyChanged(nameof(Answer3));
                answer4 = Question1.A4;
                OnPropertyChanged(nameof(Answer4));
                return;
            }
            if (QuestionNum == "2")
            {

                description = Question2.Text;
                OnPropertyChanged(nameof(Description));
                answer1 = Question2.A1;
                OnPropertyChanged(nameof(Answer1));
                answer2 = Question2.A2;
                OnPropertyChanged(nameof(Answer2));
                answer3 = Question2.A3;
                OnPropertyChanged(nameof(Answer3));
                answer4 = Question2.A4;
                OnPropertyChanged(nameof(Answer4));
                return;
            }
            if (QuestionNum == "3")
            {

                description = Question3.Text;
                OnPropertyChanged(nameof(Description));
                answer1 = Question3.A1;
                OnPropertyChanged(nameof(Answer1));
                answer2 = Question3.A2;
                OnPropertyChanged(nameof(Answer2));
                answer3 = Question3.A3;
                OnPropertyChanged(nameof(Answer3));
                answer4 = Question3.A4;
                OnPropertyChanged(nameof(Answer4));
                return;
            }
            if (QuestionNum == "4")
            {

                description = Question4.Text;
                OnPropertyChanged(nameof(Description));
                answer1 = Question4.A1;
                OnPropertyChanged(nameof(Answer1));
                answer2 = Question4.A2;
                OnPropertyChanged(nameof(Answer2));
                answer3 = Question4.A3;
                OnPropertyChanged(nameof(Answer3));
                answer4 = Question4.A4;
                OnPropertyChanged(nameof(Answer4));
                return;
            }
            else
            {
                // Throw some kind of exception.
            }

        } // End OnAppearing

        // On navigation, set the radio button selection, no selection if 0.
        // Call using QuestionNum as the arg.
        private void RadioSet(string num)
        {
            // Find the selection varaible that matches the current page.
            string question = "0";
            if(num == "1")
            {
                question = Selection1;
            }
            if (num == "2")
            {
                question = Selection2;
            }
            if (num == "3")
            {
                question = Selection3;
            }
            if (num == "4")
            {
                question = Selection4;
            }

            // What page we are on is now trivial, make the radio button matching 
            // "question" selected.
            if (question == "0")
            {
                return;
            }
            if(question == "1")
            {
                radio1 = true;
                OnPropertyChanged(nameof(Radio1));
                return;
            }
            if (question == "2")
            {
                radio2 = true;
                OnPropertyChanged(nameof(Radio2));
                return;
            }
            if (question == "3")
            {
                radio3 = true;
                OnPropertyChanged(nameof(Radio3));
                return;
            }
            if (question == "4")
            {
                radio4 = true;
                OnPropertyChanged(nameof(Radio4));
                return;
            }

        }

        // Change the value of PassQuestionNum and update the string QuestionNum.
        // Use true arg for addition and false arg for subtraction.
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

        // Open new instance of QuestionPage.
        private async void OnQuiz1Clicked(object obj)
        {
            ChangeQNum(true);
            if(PassQuestionNum == 5)
            {
                await Shell.Current.GoToAsync($"{nameof(QuizSubmitPage)}?questionNum={PassQuestionNum}&selection1={Selection1}&selection2={Selection2}&selection3={Selection3}&selection4={Selection4}");
            }
            if(PassQuestionNum < 5)
            {
                await Shell.Current.GoToAsync($"{nameof(QuestionPage)}?questionNum={PassQuestionNum}&selection1={Selection1}&selection2={Selection2}&selection3={Selection3}&selection4={Selection4}");
            }
            else
            {
                // Throw exception.
            }
            
        }
        // Close instance of QuestionPage.
        private async void OnSwipeRight(object obj)
        {
            // This will pop the current page off the navigation stack.
            // Forms.Shell makes the page disapear without an animation.
            ChangeQNum(false);
            await Shell.Current.GoToAsync($"..?questionNum={PassQuestionNum}&selection1={Selection1}&selection2={Selection2}&selection3={Selection3}&selection4={Selection4}");
        }

        // Handles changes to the answer radio buttons.
        private void OnOptionSelected(object obj)
        {
            if(obj.ToString() == "1")
            {
                SetSelection("1");
                return;
            }
            if (obj.ToString() == "2")
            {
                SetSelection("2");
                return;
            }
            if (obj.ToString() == "3")
            {
                SetSelection("3");
                return;
            }
            if (obj.ToString() == "4")
            {
                SetSelection("4");
                return;
            }
            else
            {
                return;
            }
        }
        
        // Method that sets the appropriate Selection variable for OnOptionSelected.
        private void SetSelection(string selected)
        {
            if (QuestionNum == "1")
            {
                Selection1 = selected;
                return;
            }
            if (QuestionNum == "2")
            {
                Selection2 = selected;
                return;
            }
            if (QuestionNum == "3")
            {
                Selection3 = selected;
                return;
            }
            if (QuestionNum == "4")
            {
                Selection4 = selected;
                return;
            }
            else
            {
                // Exit the method if we have navigated outside the index of questions.
                return;
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

        // Description of the qeustion.
        string description = "Defualt description.";

        public string Description
        {
            get => description;
            set
            {
                SetProperty(ref description, value);
                OnPropertyChanged(nameof(Description));
            }
        }

        // First anser displayed.
        string answer1 = "answer1";

        public string Answer1
        {
            get => answer1;
            set
            {
                SetProperty(ref answer1, value);
                OnPropertyChanged(nameof(Answer1));
            }
        }

        // Second answer displayed.
        string answer2 = "answer2";

        public string Answer2
        {
            get => answer2;
            set
            {
                SetProperty(ref answer2, value);
                OnPropertyChanged(nameof(Answer2));
            }
        }

        // Third answer displayed.
        string answer3 = "answer3";

        public string Answer3
        {
            get => answer3;
            set
            {
                SetProperty(ref answer3, value);
                OnPropertyChanged(nameof(Answer3));
            }
        }

        // Fourth answer displayed.
        string answer4 = "answer4";

        public string Answer4
        {
            get => answer4;
            set
            {
                SetProperty(ref answer4, value);
                OnPropertyChanged(nameof(Answer4));
            }
        }

        // Bound to the IsChecked field on the radio buttons.
        bool radio1;
        public bool Radio1
        {
            get => radio1;
            set
            {
                SetProperty(ref radio1, value);
                OnPropertyChanged(nameof(Radio1));
            }
        }

        // Bound to the IsChecked field on the radio buttons.
        bool radio2;
        public bool Radio2
        {
            get => radio2;
            set
            {
                SetProperty(ref radio2, value);
                OnPropertyChanged(nameof(Radio2));
            }
        }

        // Bound to the IsChecked field on the radio buttons.
        bool radio3;
        public bool Radio3
        {
            get => radio3;
            set
            {
                SetProperty(ref radio3, value);
                OnPropertyChanged(nameof(Radio3));
            }
        }

        // Bound to the IsChecked field on the radio buttons.
        bool radio4;
        public bool Radio4
        {
            get => radio4;
            set
            {
                SetProperty(ref radio4, value);
                OnPropertyChanged(nameof(Radio4));
            }
        }

        // Time remaining
        string countdown = "XX:YY";

        public string Countdown
        {
            get => countdown;
            set
            {
                SetProperty(ref countdown, value);
                OnPropertyChanged(nameof(Countdown));
                OnPropertyChanged(nameof(TimeDisplay));
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

        public string TimeDisplay => $"Time remaining: {Countdown}";

        // Hard coded data ##################################################
        public Quiz AusHistory = new Quiz()
        {
            QuizID = "Q1",
            Title = "Australian History",
            Topic = "An example of a quiz with made up questions.",
            TotalExp = 400,
            TimeLimit = 5,
            NumQuestions = 4
        };

        public Question Question1 = new Question()
        {
            QuizID = "Q1",
            Text = "Who won the Great Emu War?",
            ID = "1",
            A1 = "Koalas",
            A2 = "Humans",
            A3 = "Emus",
            A4 = "Snakes",
            Correct = "Emus",
            Exp = 100
        };

        public Question Question2 = new Question()
        {
            QuizID = "Q1",
            Text = "When did Australia become a federation?",
            ID = "2",
            A1 = "1888",
            A2 = "1960",
            A3 = "1788",
            A4 = "1901",
            Correct = "1901",
            Exp = 100
        };

        public Question Question3 = new Question()
        {
            QuizID = "Q1",
            Text = "Who was Australia's first prime minister?",
            ID = "3",
            A1 = "Edmund Barton",
            A2 = "Billy Hughes",
            A3 = "Alfred Deakon",
            A4 = "Joseph Cook",
            Correct = "Edmund Barton",
            Exp = 100
        };

        public Question Question4 = new Question()
        {
            QuizID = "Q1",
            Text = "When was Australia colonised?",
            ID = "4",
            A1 = "1788",
            A2 = "1658",
            A3 = "1880",
            A4 = "1772",
            Correct = "1788",
            Exp = 100
        };
    }
}
