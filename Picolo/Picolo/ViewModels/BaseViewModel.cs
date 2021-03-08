using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Picolo.Models;
using Picolo.Services;

namespace Picolo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Quest> QuestDataStore => DependencyService.Get<IDataStore<Quest>>();
        public IDataStore<Quiz> QuizDataStore => DependencyService.Get<IDataStore<Quiz>>();
        public static IDataStore<User> UserDataStore => DependencyService.Get<IDataStore<User>>();
        public IDataStore<Groups> GroupDataStore => DependencyService.Get<IDataStore<Groups>>();

        //Convert experience (personal/group) into appropriate level information
        public Tuple<int, int, int, double> ExperienceToLevel(int e)
        {
            int level = e / 1000 + 1; //Convert Exp into level 
            int levelExp = e % 1000; //Amount of Exp into the current level
            int remainingExp = 1000 - levelExp; //Amount of Exp needed for next level 
            double ExpToPercentage = (double)levelExp / 1000; //Use for setting progress in progress bars

            return Tuple.Create(level, levelExp, remainingExp, ExpToPercentage);
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
