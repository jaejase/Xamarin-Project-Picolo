// Written by Minseong (Jason) Kim N10218807

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Picolo.Models;
using Picolo.Views;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Picolo.ViewModels
{
    class ProfilePageViewModel : BaseViewModel
    {
        //public ObservableCollection<User> Person { get; }

        public Command LoadUsersCommand { get; }
        public Command GoToSettingsCommand { get; }
        public Command RefreshData { get; }

        bool isLoaded = false;


        //trophy
        public string Trophy5Gained { get; set; }
        public string Trophy6Gained { get; set; }
        public string Trophy7Gained { get; set; }
        public string Trophy8Gained { get; set; }
        public string Trophy9Gained { get; set; }

        //experience
        public string PersonalLevel { get; set; }
        public string PersonalLevelEXP { get; set; }
        public string PersonalRemainingEXP { get; set; }
        public string PersonalProgressBar { get; set; }

        public string PartyLevel { get; set; }
        public string PartyLevelEXP { get; set; }
        public string PartyRemainingEXP { get; set; }
        public string PartyProgressBar { get; set; }

        //level

        //statistics
        public int QuestionsAnswered { get; set; }
        public int QuestsCompleted { get; set; }
        public int CommentsPosted { get; set; }
        public int AverageQuizAccuracy { get; set; }
        public int AverageTimeTakenEachActivity { get; set; }

        //myprogress
        public string MyProgressImage1 { get; set; }
        public string MyProgressTitle1 { get; set; }
        public string MyProgressEXP1 { get; set; }
        public double MyProgressEXPBar1 { get; set; }
        public string MyProgressImage2 { get; set; }
        public string MyProgressTitle2 { get; set; }
        public string MyProgressEXP2 { get; set; }
        public double MyProgressEXPBar2 { get; set; }
        public string MyProgressImage3 { get; set; }
        public string MyProgressTitle3 { get; set; }
        public string MyProgressEXP3 { get; set; }
        public double MyProgressEXPBar3 { get; set; }

        //level image
        public bool Level9Image { get; set; }
        public bool Level10Image { get; set; }

        public ProfilePageViewModel()
        {
            OnAppearing();
            CalculateEXP();
            GetMyProgress();
            GoToSettingsCommand = new Command(GoToSettings);
            RefreshData = new Command(RefreshDataCommand);
        }

        public async void RefreshDataCommand()
        {
            await Shell.Current.GoToAsync(nameof(ProfilePage));

        }

        protected async void OnAppearing()
        {
            if (!isLoaded)
            {
                try
                {
                    //Person.Clear();
                    var users = await UserDataStore.GetItemsAsync(true);
                    foreach (var user in users)
                    {
                        if (user.Name == "User1")
                        {
                            Trophy5Gained = user.Trophy5Gained.ToString();
                            Trophy6Gained = user.Trophy6Gained.ToString();
                            Trophy7Gained = user.Trophy7Gained.ToString();
                            Trophy8Gained = user.Trophy8Gained.ToString();
                            Trophy9Gained = user.Trophy9Gained.ToString();

                            //statistics
                            QuestionsAnswered = user.QuestionsAnswered;
                            QuestsCompleted = user.QuestsCompleted;
                            CommentsPosted = user.CommentsPosted;
                            AverageQuizAccuracy = user.AverageQuizAccuracy;
                            AverageTimeTakenEachActivity = user.AverageTimeTakenEachActivity;
                        }
                    }

                    isLoaded = true;
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }



        private async void CalculateEXP()
        {
            //Personal Experience
            var user1 = await UserDataStore.GetItemsAsync(true);
            foreach (var user in user1)
            {
                if (user.Name == "User1")
                {
                    var result = ExperienceToLevel(user.PersonalExperience);
                    PersonalLevel = result.Item1.ToString();
                    PersonalLevelEXP = result.Item2.ToString();
                    PersonalRemainingEXP = result.Item3.ToString();
                    PersonalProgressBar = result.Item4.ToString();

                    if (result.Item1 == 9)
                    {
                        Level9Image = true;
                        Level10Image = false;
                    }
                    else
                    {
                        Level9Image = false;
                        Level10Image = true;
                    }

                    var result2 = ExperienceToLevel(user.PartyExperience);
                    PartyLevel = result2.Item1.ToString();
                    PartyLevelEXP = result2.Item2.ToString();
                    PartyRemainingEXP = result2.Item3.ToString();
                    PartyProgressBar = result2.Item4.ToString();
                }
            }
        }

        private void GetMyProgress()
        {
            //group formation
            if (Trophy5Gained == "True" && Trophy6Gained == "False")
            {
                MyProgressImage1 = "trophy6.png";
                MyProgressTitle1 = "Party Maker";
                MyProgressEXP1 = "0/1";
                MyProgressEXPBar1 = 0;
                MyProgressImage2 = "trophy7.png";
                MyProgressTitle2 = "Goal Striver";
                MyProgressEXP2 = "16/180 EXP";
                MyProgressEXPBar2 = 0.0888;
                MyProgressImage3 = "trophy8.png";
                MyProgressTitle3 = "Path Finder";
                MyProgressEXP3 = "330/950 EXP";
                MyProgressEXPBar3 = 0.3474;
            }

            if (Trophy6Gained == "True" && Trophy7Gained == "False")
            {
                MyProgressImage1 = "trophy7.png";
                MyProgressTitle1 = "Goal Striver";
                MyProgressEXP1 = "16/180 EXP";
                MyProgressEXPBar1 = 0.0888;
                MyProgressImage2 = "trophy8.png";
                MyProgressTitle2 = "Path Finder";
                MyProgressEXP2 = "330/950 EXP";
                MyProgressEXPBar2 = 0.3474;
                MyProgressImage3 = "trophy9.png";
                MyProgressTitle3 = "Great Explorer";
                MyProgressEXP3 = "0/465 EXP";
                MyProgressEXPBar3 = 0;
            }
        }

        private async void GoToSettings(object obj)
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));

        }
    }
}
