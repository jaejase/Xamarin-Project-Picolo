using Picolo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Picolo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public object Users { get; set; }
		public ProfilePage()
		{
			InitializeComponent();
			this.BindingContext = new ProfilePageViewModel();
		}

		async void Trophy1ButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Trophy 1", "Description: This trophy is awarded for being a great goal striver", "OK");
		}

		async void Trophy2ButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Trophy 2", "Description: This trophy is awarded for being a fast learner", "OK");
		}

		async void Trophy3ButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Trophy 3", "Description: This trophy is awarded for being a persistent learner", "OK");
		}

		async void Trophy4ButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Trophy 4", "Description: This trophy is awarded for trying your best at all times", "OK");
		}

		async void Trophy5ButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Trophy 5", "Description: This trophy is awarded for being responsible student", "OK");
		}

		async void Trophy6ButtonClicked(object sender, EventArgs e)
		{
			await DisplayAlert("Trophy 6", "Description: This trophy is awarded for contributing to your team", "OK");
		}
	}
}