using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Picolo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Picolo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizSummaryPage : ContentPage
    {
        public QuizSummaryPage()
        {
            InitializeComponent();
            this.BindingContext = new QuizSummaryViewModel();
        }
    }
}