using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Picolo.Models;
using Picolo.Views;
using Picolo.Services;
using MvvmHelpers;
using System.Threading.Tasks;
namespace Picolo.ViewModels

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>
{
    [QueryProperty("Selection1", "selection1")]
    [QueryProperty("Selection2", "selection2")]
    [QueryProperty("Selection3", "selection3")]
    [QueryProperty("Selection4", "selection4")]
    class QuizSummaryViewModel : BaseViewModel
    {
        public Command CompletedCommand { get; }
        public QuizSummaryViewModel()
        {
            OnAppearing();
            Title = "Quiz Summary";
            CompletedCommand = new Command(OnCompletion);
            //await Shell.Current.Navigation.PopToRootAsync();
        }

        protected async void OnAppearing()
        {
            // Do something on startup.
            await Task.Delay(30);
            OnPropertyChanged(nameof(QSummary1));
            OnPropertyChanged(nameof(QSummary2));
            OnPropertyChanged(nameof(QSummary3));
            OnPropertyChanged(nameof(QSummary4));
            //QSummary1 = Summary("1", Selection1, Question1);
            //OnPropertyChanged(nameof(QSummary1));
        }

        private async void OnCompletion(object obj)
        {
            await Shell.Current.GoToAsync(nameof(QuestLog));
        }

        // Creates a string that summarizes the a question.
        private string Summary(string q, string selection, Question question)
        {
            string result = "null";
            string iscorrect = "Incorrect";
            string answer = "I dunno";
            string exp = "0";

            if (selection == "1")
            {
                answer = question.A1;
            }
            else if (selection == "2")
            {
                answer = question.A2;
            }
            else if (selection == "3")
            {
                answer = question.A3;
            }
            else if (selection == "4")
            {
                answer = question.A4;
            }
            else
            {
                answer = "I dunno";
            }

            if (question.Correct == answer)
            {
                iscorrect = "Correct";
            }
            else
            {
                iscorrect = "Incorrect";
            }

            if(iscorrect == "Correct")
            {
                exp = question.Exp.ToString();
            }
            else
            {
                exp = "0";
            }

            result = $"Qustion {q}: " +
                $"{iscorrect}   " +
                $"Exp earned: {exp}\n" +
                $"Your answer: {answer}\n" +
                $"Correct answer: {question.Correct}\n";

            return result;
        } // End Summary method.

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
                OnPropertyChanged(nameof(QSummary1));
            }
        }

        public string QSummary1 => Summary("1", Selection1, Question1);
        

        string selection2 = "0";
        public string Selection2
        {
            get => selection2;
            set
            {
                SetProperty(ref selection2, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Selection2));
                OnPropertyChanged(nameof(QSummary2));
            }
        }
        public string QSummary2 => Summary("2", Selection2, Question2);

        string selection3 = "0";
        public string Selection3
        {
            get => selection3;
            set
            {
                SetProperty(ref selection3, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Selection3));
                OnPropertyChanged(nameof(QSummary3));
            }
        }
        public string QSummary3 => Summary("3", Selection3, Question3);

        string selection4 = "0";
        public string Selection4
        {
            get => selection4;
            set
            {
                SetProperty(ref selection4, Uri.UnescapeDataString(value));
                OnPropertyChanged(nameof(Selection4));
                OnPropertyChanged(nameof(QSummary4));
            }
        }
        public string QSummary4 => Summary("4", Selection4, Question4);

        string summaryTitle = "Quiz Results: Australian History";
        public string SummaryTitle
        {
            get => summaryTitle;
            set
            {
                SetProperty(ref summaryTitle, value);
                OnPropertyChanged(nameof(SummaryTitle));
            }
        }

        // Questions hard coded data ######################################

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
