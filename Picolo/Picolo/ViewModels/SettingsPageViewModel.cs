// Written by Minseong (Jason) Kim N10218807

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Picolo.Views;

namespace Picolo.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public Command DirectToTheme { get; }
        public SettingsPageViewModel()
        {
            Title = "Theme";
            DirectToTheme = new Command(ThemePageClicked);
        }
        public async void ThemePageClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(ThemeSelectionPage)}");
        }


    }
}
