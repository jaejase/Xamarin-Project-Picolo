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
    public partial class PartySelection : ContentPage
    {
        public PartySelection()
        {
            InitializeComponent();
            this.BindingContext = new PartySelectionViewModel();
        }
    }
}