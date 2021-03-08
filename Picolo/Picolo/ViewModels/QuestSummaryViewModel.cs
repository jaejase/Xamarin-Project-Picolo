// Written by Mia Basta N10246771
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Picolo.Models;
using Picolo.Views;
using Picolo.Services;

/// <summary>
/// 
/// Created by: Mia Basta - N10246771
/// 
/// This page is a placeholder for the original Quiz Summary page from the 
/// Quiz Feature. It exists to show functionality of the Quest Log "Completed" 
/// tab and is not fully functional with the current Quiz feature.
/// 
/// 
/// </summary>

namespace Picolo.ViewModels
{
    [QueryProperty("QuestName", "QuestName")]

    class QuestSummaryViewModel : BaseViewModel
    {
        public string questName;
        public string QuestName
        {
            get { return questName; }
            set { questName = Uri.UnescapeDataString(value ?? string.Empty); OnPropertyChanged(); }
        }
        public Command CloseCommand { get; }

        public QuestSummaryViewModel()
        {
            CloseCommand = new Command(OnClose);
        }
        private async void OnClose()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
