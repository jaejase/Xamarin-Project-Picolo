// Written by Aaron Hayton N9946977
using Picolo.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Picolo.ViewModels
{
    class HatQuizViewModel : BaseViewModel
    {

        // Continue to quiz 
        public Command StartHatQuiz { get; }
        public HatQuizViewModel()
        {
            Title = "Six Hat Survey";
            StartHatQuiz = new Command(OnHatClicked);
        }
        public async void OnHatClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(HatQuizQuestion)}");
        }

    }
}
