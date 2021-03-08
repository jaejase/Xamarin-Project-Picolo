// Written by Aaron Hayton N9946977
using Picolo.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Picolo.Models;

namespace Picolo.ViewModels
{
    class HatQuizQuestionViewModel : BaseViewModel
    {
        // Continue to survey result 
        public Command WhiteSubmit { get; }
        public Command BlackSubmit { get; }
        public Command GreenSubmit { get; }
        public Command BlueSubmit { get; }
        public Command YellowSubmit { get; }
        public Command RedSubmit { get; }
        public int QuestsCompleted1 { get; set; }
        public int PersonalExperience1 { get; set; }

        public HatQuizQuestionViewModel()
        {
            Title = "Six Hat Survey";
            WhiteSubmit = new Command(OnQuizSubmitWhite);
            BlackSubmit = new Command(OnQuizSubmitBlack);
            GreenSubmit = new Command(OnQuizSubmitGreen);
            RedSubmit = new Command(OnQuizSubmitRed);
            BlueSubmit = new Command(OnQuizSubmitBlue);
            YellowSubmit = new Command(OnQuizSubmitYellow);
        }
        public async void OnQuizSubmitWhite(object obj)
        {
            var user1 = await UserDataStore.GetItemAsync("User1");
            QuestsCompleted1 = user1.QuestsCompleted;
            PersonalExperience1 = user1.PersonalExperience;

            User newUser = new User()
            {
                Name = "User1",
                Username = "wHoaMI",
                Password = null,
                PersonalExperience = PersonalExperience1 + 500,
                PartyExperience = 2100,
                HatColour = "White", // This needs to be updated when hat quiz is completed

                //statistics
                QuestionsAnswered = 75,
                QuestsCompleted = QuestsCompleted1,

                //trophygained
                Trophy5Gained = true,
                Trophy6Gained = false,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false,
            };
            await UserDataStore.UpdateItemAsync(newUser);
            await Shell.Current.GoToAsync($"{nameof(HatQuizResult)}");
        }
        public async void OnQuizSubmitBlack(object obj)
        {
            var user1 = await UserDataStore.GetItemAsync("User1");
            QuestsCompleted1 = user1.QuestsCompleted;
            PersonalExperience1 = user1.PersonalExperience;
            User newUser = new User()
            {
                Name = "User1",
                Username = "wHoaMI",
                Password = null,
                PersonalExperience = PersonalExperience1 + 500,
                PartyExperience = 2100,
                HatColour = "Black", // This needs to be updated when hat quiz is completed

                //statistics
                QuestionsAnswered = 13,
                QuestsCompleted = QuestsCompleted1,

                //trophygained
                Trophy5Gained = true,
                Trophy6Gained = false,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false,
            };
            await UserDataStore.UpdateItemAsync(newUser);
            await Shell.Current.GoToAsync($"{nameof(HatQuizResult)}");
        }
        public async void OnQuizSubmitBlue(object obj)
        {
            var user1 = await UserDataStore.GetItemAsync("User1");
            QuestsCompleted1 = user1.QuestsCompleted;
            PersonalExperience1 = user1.PersonalExperience;
            User newUser = new User()
            {
                Name = "User1",
                Username = "wHoaMI",
                Password = null,
                PersonalExperience = PersonalExperience1 + 500,
                PartyExperience = 2100,
                HatColour = "Blue", // This needs to be updated when hat quiz is completed

                //statistics
                QuestionsAnswered = 13,
                QuestsCompleted = QuestsCompleted1,

                //trophygained
                Trophy5Gained = true,
                Trophy6Gained = false,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false,
            };
            await UserDataStore.UpdateItemAsync(newUser);
            await Shell.Current.GoToAsync($"{nameof(HatQuizResult)}");
        }
        public async void OnQuizSubmitGreen(object obj)
        {
            var user1 = await UserDataStore.GetItemAsync("User1");
            QuestsCompleted1 = user1.QuestsCompleted;
            PersonalExperience1 = user1.PersonalExperience;
            User newUser = new User()
            {
                Name = "User1",
                Username = "wHoaMI",
                Password = null,
                PersonalExperience = PersonalExperience1 + 500,
                PartyExperience = 2100,
                HatColour = "Green", // This needs to be updated when hat quiz is completed

                //statistics
                QuestionsAnswered = 13,
                QuestsCompleted = QuestsCompleted1,

                //trophygained
                Trophy5Gained = true,
                Trophy6Gained = false,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false,
            };
            await UserDataStore.UpdateItemAsync(newUser);
            await Shell.Current.GoToAsync($"{nameof(HatQuizResult)}");
        }
        public async void OnQuizSubmitRed(object obj)
        {
            var user1 = await UserDataStore.GetItemAsync("User1");
            QuestsCompleted1 = user1.QuestsCompleted;
            PersonalExperience1 = user1.PersonalExperience;
            User newUser = new User()
            {
                Name = "User1",
                Username = "wHoaMI",
                Password = null,
                PersonalExperience = PersonalExperience1 + 500,
                PartyExperience = 2100,
                HatColour = "Red", // This needs to be updated when hat quiz is completed

                //statistics
                QuestionsAnswered = 13,
                QuestsCompleted = QuestsCompleted1,

                //trophygained
                Trophy5Gained = true,
                Trophy6Gained = false,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false,
            };
            await UserDataStore.UpdateItemAsync(newUser);
            await Shell.Current.GoToAsync($"{nameof(HatQuizResult)}");
        }
        public async void OnQuizSubmitYellow(object obj)
        {
            var user1 = await UserDataStore.GetItemAsync("User1");
            QuestsCompleted1 = user1.QuestsCompleted;
            PersonalExperience1 = user1.PersonalExperience;
            User newUser = new User()
            {
                Name = "User1",
                Username = "wHoaMI",
                Password = null,
                PersonalExperience = PersonalExperience1 + 500,
                PartyExperience = 2100,
                HatColour = "Yellow", // This needs to be updated when hat quiz is completed

                //statistics
                QuestionsAnswered = 13,
                QuestsCompleted = QuestsCompleted1,

                //trophygained
                Trophy5Gained = true,
                Trophy6Gained = false,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false,
            };
            await UserDataStore.UpdateItemAsync(newUser);
            await Shell.Current.GoToAsync($"{nameof(HatQuizResult)}");
        }
    }
}

