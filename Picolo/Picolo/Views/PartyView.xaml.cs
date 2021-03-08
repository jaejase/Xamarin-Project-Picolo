using Picolo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picolo.Models;
using Picolo.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Picolo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartyView : ContentPage
    {
        public PartyPageViewModel vm;
        public PartyView()
        {
            InitializeComponent();
            this.BindingContext = vm = new PartyPageViewModel();

            NavigationPage.SetHasBackButton(this, false);

            MessagingCenter.Subscribe<PartySelectionViewModel, string>(this, "popped", (sender, arg) =>
            {
                Console.WriteLine("Refresh Party View");
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }

    }
}