using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Picolo.Models;
using Picolo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Picolo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void CreateButtonClicked(object sender, EventArgs e)
        {
            //var user = new User()
            //{
            //    //Username = usernameEntry.Text,
            //    //Password = passwordEntry.Text
            //};
        }
    }
}