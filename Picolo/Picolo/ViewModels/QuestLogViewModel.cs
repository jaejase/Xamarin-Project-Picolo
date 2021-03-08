// Written by Mia Basta N10246771
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Picolo.Models;
using Picolo.Views;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.ViewModels
{
    class QuestLogViewModel : BaseViewModel
    {
        public ObservableCollection<Quest> Quests { get; }
        public ObservableCollection<Quest> Dailies { get; }
        public ObservableCollection<Quest> Completed { get; }
        public Command LoadQuestsCommand { get; }
        public Command LoadDailiesCommand { get; }
        public Command LoadCompletedCommand { get; }
        public Command GoToSettingsCommand { get; }
        public Command BeginQuestCommand { get; }
        public Command ViewQuestSummaryCommand { get; }
        public Command OnTapped { get; }

        bool isLoaded;
        string personallevel;

        //User information
        public string PersonalLevel
        {
            get => personallevel;
            set
            {
                SetProperty(ref personallevel, value);
                OnPropertyChanged(nameof(PersonalLevel));
            }
        }
        public string PersonalExpAmount { get; set; }
        public double PersonalExpPercentage { get; set; }
        public string Username { get; set; }

        //Party information
        public string PartyLevel { get; set; }
        public string PartyExpAmount { get; set; }
        public double PartyExpPercentage { get; set; }

        public QuestLogViewModel()
        {
            Title = "Quest Log";
      
            Quests = new ObservableCollection<Quest>();
            LoadQuestsCommand = new Command(async () => await ExecuteLoadQuestsCommand());

            Dailies = new ObservableCollection<Quest>();
            LoadDailiesCommand = new Command(async () => await ExecuteLoadDailiesCommand());

            Completed = new ObservableCollection<Quest>();
            LoadCompletedCommand = new Command(async () => await ExecuteLoadCompletedCommand());

            GoToSettingsCommand = new Command(GoToSettings); 
            
            ViewQuestSummaryCommand = new Command(ViewQuestSummary);
            
            BeginQuestCommand = new Command(BeginQuest);

            OnAppearing();
        }

        public async void ViewQuestSummary(object obj)
        {
            string questName = (string)obj;
            await Shell.Current.GoToAsync($"{nameof(QuestSummary)}?QuestName={questName}");
        }
        public async void BeginQuest(object obj)
        {
            if (obj == "group") await Shell.Current.GoToAsync(nameof(HatQuiz));

            if (obj == "quiz1") await Shell.Current.GoToAsync(nameof(QuizBrowserPage));

            //Temporary fix. Intended to grey out/disable the button if quest unavailable.
            if (obj == "quiz") await App.Current.MainPage.DisplayAlert("You Shall Not Pass", "You are not ready to embark on this Quest. Return at a later date.", "Understood");
        }
        protected async void OnAppearing()
        {
            if (!isLoaded)
            {
                ExecuteLoadQuestsCommand();
                ExecuteLoadDailiesCommand();
                ExecuteLoadCompletedCommand();
                AddUserInformation();
                isLoaded = true;
            }
        } 
        async Task AddUserInformation()
        {
            //Personal Experience
            var user1 = await UserDataStore.GetItemsAsync(true);
            foreach (var user in user1)
            {
                if (user.Name == "User1")
                {
                    Username = user.Username;

                    var result = ExperienceToLevel(user.PersonalExperience);
                    PersonalLevel = result.Item1.ToString();
                    PersonalExpAmount = result.Item2.ToString();
                    PersonalExpPercentage = result.Item4;
                    
                    var result2 = ExperienceToLevel(user.PartyExperience);
                    if (user.HatColour == null) PartyLevel = " Lone Wolf";
                    else
                    {
                        PartyLevel = result2.Item1.ToString();
                        PartyExpAmount = result2.Item2.ToString();
                    }
                    PartyExpPercentage = result2.Item4;
                }
            }
        }
        async Task ExecuteLoadQuestsCommand()
        {
            try
            {
                Quests.Clear();
                var quests = await QuestDataStore.GetItemsAsync(true);
                foreach (var quest in quests)
                {
                    if (quest.Type != "daily" && quest.Status != "complete")
                    {
                        //Apply quiz icon
                        if (quest.Type == "quiz" && quest.Id != "quiz1") quest.Icon = "lock_color.png";
                        //Apply group icon
                        if (quest.Type == "group" || quest.Id == "quiz1") quest.Icon = "urgent_color.png";
                        Quests.Add(quest);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        async Task ExecuteLoadCompletedCommand()
        {
            try
            {
                Completed.Clear();
                var completed = await QuestDataStore.GetItemsAsync(true);
                foreach (var complete in completed)
                {
                    if (complete.Status == "complete")
                    {
                        if (((double)complete.QuestResult / complete.NumQuestions) > 0.5)
                        {
                            complete.QuestColor = "#77d353";
                            complete.Icon = "pass_color.png";
                            complete.QuestResults = complete.QuestResult.ToString() + "/" + complete.NumQuestions.ToString();
                        }
                        if (((double)complete.QuestResult / complete.NumQuestions) <= 0.5)
                        {
                            complete.QuestColor = "#f95f62";
                            complete.Icon = "fail_color.png";
                            complete.QuestResults = complete.QuestResult.ToString() + "/" + complete.NumQuestions.ToString();
                        }
                        if (complete.Type == "group")
                        {
                            complete.QuestColor = "#77d353";
                            complete.Icon = "pass_color.png";
                            complete.QuestResults = null;
                        }
                        Completed.Add(complete);
                    }
                }
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
        async Task ExecuteLoadDailiesCommand()
        {
            try
            {
                Dailies.Clear();
                var dailies = await QuestDataStore.GetItemsAsync(true);
                foreach (var daily in dailies)
                {
                    if (daily.Type == "daily")
                        Dailies.Add(daily);
                }
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
        private async void GoToSettings(object obj)
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));

        }
    }
}
