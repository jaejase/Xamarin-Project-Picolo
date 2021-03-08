using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Picolo.Views;

namespace Picolo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command DirectToCreateAccount { get; }
        public LoginViewModel()
        {
            Title = "Sign up";
            DirectToCreateAccount = new Command(SignupClicked);
        }
        public async void SignupClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
        }
    }
}
