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
using System.Data;

namespace Picolo.ViewModels
{
    public class PartyPageViewModel : BaseViewModel
    {
        bool isLoaded = false;
        // Group information
        public string GroupName { get; set; }
        public double GroupPercent { get; set; }
        public string GroupLevel { get; set; }
        // User Levels, Names and Progress Bar
        public string User1Level { get; set; }
        public string User2Level { get; set; }
        public string User3Level { get; set; }
        public string User4Level { get; set; }
        public string User1Name { get; set; }
        public string User2Name { get; set; }
        public string User3Name { get; set; }
        public string User4Name { get; set; }
        public double User1Percent { get; set; }
        public double User2Percent { get; set; }
        public double User3Percent { get; set; }
        public double User4Percent { get; set; }
        public Command FillData { get; }

        public PartyPageViewModel()
        {
            Title = "My Party";
            GroupName = "Please Refresh Me";
            FillData = new Command(Refresh);
            OnAppearing();    
        }

        // This code is needed to prevent a bug in xamarin where the popping of a navigation stack does not run the OnAppearing for this page
        public async void Refresh()
        {
            await Shell.Current.GoToAsync($"{nameof(PartyView)}");
        }
        public async void OnAppearing()
        {
            if (!isLoaded)
            {
                //Get all groups to check for data where user exists
                var users = await UserDataStore.GetItemsAsync();

                foreach (var user in users)
                {
                    if (user.Name == "User1")
                    {
                        if (user.HatColour == null)
                        {
                            await App.Current.MainPage.DisplayAlert("You're not in a party yet!", "Complete the Quest to join a party first.", "Continue");
                            //await Shell.Current.Navigation.PopToRootAsync().ConfigureAwait(true);
                            //await Shell.Current.GoToAsync($"{nameof(HatQuiz)}"); // If user is not in group go to HatQuiz
                            break;
                        }
                        else
                        {
                            FillUserData();
                            break;
                        }
                    }
                }
            }
        }
        public async void FillUserData()
        {
            var groups = await GroupDataStore.GetItemsAsync();
            var users = await UserDataStore.GetItemsAsync();
            foreach (var group in groups)
            {
                if (group.MemberId4 == "User1")
                {
                    //Add group data
                    GroupName = group.GroupName;
                    var result = ExperienceToLevel(group.GroupXP);
                    GroupLevel = result.Item1.ToString();
                    GroupPercent = result.Item4;
                    //Add first user data
                    var user1 = await UserDataStore.GetItemAsync(group.MemberId1);
                    var result1 = ExperienceToLevel(user1.PersonalExperience);
                    User1Name = user1.Username;
                    User1Level = result1.Item1.ToString();
                    User1Percent = result1.Item4;
                    //Add second user data
                    var user2 = await UserDataStore.GetItemAsync(group.MemberId2);
                    var result2 = ExperienceToLevel(user2.PersonalExperience);
                    User2Name = user2.Username;
                    User2Level = result2.Item1.ToString();
                    User2Percent = result2.Item4;
                    //Add third user data
                    var user3 = await UserDataStore.GetItemAsync(group.MemberId3);
                    var result3 = ExperienceToLevel(user3.PersonalExperience);
                    User3Name = user3.Username;
                    User3Level = result3.Item1.ToString();
                    User3Percent = result3.Item4;
                    //Add fourth user data
                    var user4 = await UserDataStore.GetItemAsync(group.MemberId4);
                    var result4 = ExperienceToLevel(user4.PersonalExperience);
                    User4Name = user4.Username;
                    User4Level = result4.Item1.ToString();
                    User4Percent = result4.Item4;

                    break;
                }
            }
        }
    }
}
