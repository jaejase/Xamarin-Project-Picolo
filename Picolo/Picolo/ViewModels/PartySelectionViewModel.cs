// Written by Aaron Hayton N9946977
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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Picolo.ViewModels
{
    class PartySelectionViewModel : BaseViewModel
    {
        public Command JoinGroup1 { get; }
        public Command JoinGroup2 { get; }

        bool isLoaded = false;

        // Group 1 information
        public string GroupName_1 { get; set; }
        public string User1_1Name { get; set; }
        public string User1_1Hat { get; set; }
        public string User1_2Name { get; set; }
        public string User1_2Hat { get; set; }
        public string User1_3Name { get; set; }
        public string User1_3Hat { get; set; }
        public string User1_4Name { get; set; }
        public string User1_4Hat { get; set; }
        // Group 2 information
        public string GroupName_2 { get; set; }
        public string User2_1Name { get; set; }
        public string User2_1Hat { get; set; }
        public string User2_2Name { get; set; }
        public string User2_2Hat { get; set; }
        public string User2_3Name { get; set; }
        public string User2_3Hat { get; set; }
        public string User2_4Name { get; set; }
        public string User2_4Hat { get; set; }

        //
        public string HatUser1 { get; set; }
        public int PersonalExperience1 { get; set; }
        public int QuestionsAnswered1 { get; set; }
        public int QuestsCompleted1 { get; set; }

        public PartySelectionViewModel()
        {
            Title = "Select a Party";
            JoinGroup1 = new Command(OnGroup1Clicked);
            JoinGroup2 = new Command(OnGroup2Clicked);
            FillGroupData();

        }

        public async void OnGroup1Clicked(object obj)
        {
            Quest newItem = new Quest()
            {
                Id = "group1",
                Status = "complete",
                Type = "group",
                Name = "Complete the Six Hats Quiz",
                Topic = "Group",
                Experience = 500,
                QuestDate = new DateTime(2020, 12, 02)
            };
            await QuestDataStore.UpdateItemAsync(newItem);

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
                PersonalExperience = PersonalExperience1,
                PartyExperience = 2100,
                HatColour = HatUser1,

                //statistics
                QuestionsAnswered = 75,
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
                Trophy6Gained = true,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false
            };

            await UserDataStore.UpdateItemAsync(newUser);

            Groups newGroup = new Groups()
            {
                Id = Guid.NewGuid().ToString(),
                GroupName = "The Nightwatchers",
                MemberId1 = "User2",
                MemberId2 = "User3",
                MemberId3 = "User4",
                MemberId4 = "User1",
                GroupXP = 2000 + 500
            };
            await GroupDataStore.UpdateItemAsync(newGroup);

            await App.Current.MainPage.DisplayAlert("Your journey begins...", "You've joined a party! View the My Party tab for your party progress.", "Continue");
            MessagingCenter.Send<PartySelectionViewModel>(this, "popped");

            await Shell.Current.GoToAsync(nameof(QuestLog));

        }

        public async void OnGroup2Clicked(object obj)
        {
            Quest newItem = new Quest()
            {
                Id = "group1",
                Status = "complete",
                Type = "group",
                Name = "Complete the Six Hats Quiz",
                Topic = "Group",
                Experience = 500,
                QuestDate = DateTime.Now
            };
            await QuestDataStore.UpdateItemAsync(newItem);

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
                PersonalExperience = PersonalExperience1,
                PartyExperience = 0 + 500,
                HatColour = HatUser1,

                //statistics
                QuestionsAnswered = 75,
                QuestsCompleted = user1.QuestsCompleted + 1,
                CommentsPosted = 3,
                AverageQuizAccuracy = 99,
                AverageTimeTakenEachActivity = 23,

                //trophygained
                Trophy1Gained = false,
                Trophy2Gained = true,
                Trophy3Gained = true,
                Trophy4Gained = true,
                Trophy5Gained = true,
                Trophy6Gained = true,
                Trophy7Gained = false,
                Trophy8Gained = false,
                Trophy9Gained = false
            };
            await UserDataStore.UpdateItemAsync(newUser);

            Groups newGroup = new Groups()
            {
                Id = Guid.NewGuid().ToString(),
                GroupName = "Crescent Regiment",
                MemberId1 = "User5",
                MemberId2 = "User6",
                MemberId3 = "User7",
                MemberId4 = "User1",
                GroupXP = 600 + 500
            };
            await GroupDataStore.UpdateItemAsync(newGroup);

            //Display an alert
            await App.Current.MainPage.DisplayAlert("Your journey begins...", "You've joined a party! View the My Party tab for your party progress.", "Continue");
            MessagingCenter.Send<PartySelectionViewModel>(this, "popped");

            await Shell.Current.Navigation.PopToRootAsync().ConfigureAwait(true);

            //await Shell.Current.GoToAsync(nameof(QuestLog));
        }

        public async void FillGroupData()
        {
            var groups = await GroupDataStore.GetItemsAsync();
            Groups[] GroupArray = groups.ToArray();

                // Fill group 1 data
                var group1 = await GroupDataStore.GetItemAsync(GroupArray[0].GroupName);
                GroupName_1 = group1.GroupName;
                var user1_1 = await UserDataStore.GetItemAsync(group1.MemberId1);
                User1_1Name = user1_1.Username;
                User1_1Hat = user1_1.HatColour.ToLower();
                var user1_2 = await UserDataStore.GetItemAsync(group1.MemberId2);
                User1_2Name = user1_2.Username;
                User1_2Hat = user1_2.HatColour.ToLower();
                var user1_3 = await UserDataStore.GetItemAsync(group1.MemberId3);
                User1_3Name = user1_3.Username;
                User1_3Hat = user1_3.HatColour.ToLower();                
                // Fill group 2 data
                var group2 = await GroupDataStore.GetItemAsync(GroupArray[1].GroupName);
                GroupName_2 = group2.GroupName;
                var user2_1 = await UserDataStore.GetItemAsync(group2.MemberId1);
                User2_1Name = user2_1.Username;
                User2_1Hat = user2_1.HatColour.ToLower();
                var user2_2 = await UserDataStore.GetItemAsync(group2.MemberId2);
                User2_2Name = user2_2.Username;
                User2_2Hat = user2_2.HatColour.ToLower();
                var user2_3 = await UserDataStore.GetItemAsync(group2.MemberId3);
                User2_3Name = user2_3.Username;
                User2_3Hat = user2_3.HatColour.ToLower();
        }
    }
}
