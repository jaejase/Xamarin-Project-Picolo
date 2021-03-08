using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Picolo.ViewModels;
namespace Picolo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitSelectionPage : ContentPage
    {
        public UnitSelectionPage()
        {
            InitializeComponent();
            this.BindingContext = new UnitSelectionViewModel();
        }
    }
}