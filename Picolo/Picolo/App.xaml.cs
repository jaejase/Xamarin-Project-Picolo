using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Picolo.Services;
using Picolo.Views;
using System.IO;
using Picolo.ViewModels;
using Picolo.Models;
using System.Collections.Generic;
using Picolo.Themes;

namespace Picolo
{
    public partial class App : Application
    {

        //public static ResourceDictionary Theme { get; set; }

        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental", "RadioButton_Experimental", "Expander_Experimental" });
            InitializeComponent();

            DependencyService.Register<UserDataStore>();
            DependencyService.Register<QuestDataStore>();
            DependencyService.Register<GroupDataStore>();
            DependencyService.Register<QuizDataStore>();
            DependencyService.Register<QuestionDataStore>();
            //DependencyService.Register<QuizAttemptDataStore>();

            

            MainPage = new AppShell();

            //Application.Current.Properties["Theme"] = "Themes/OrangeTheme.xaml";

            //Theme = (ResourceDictionary)Current.Properties["Theme"];

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
