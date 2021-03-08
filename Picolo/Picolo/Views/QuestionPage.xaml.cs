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
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
            this.BindingContext = new QuestionPageViewModel();
        }

        void SelectionHandler(object sender, CheckedChangedEventArgs e)
        {

        }
        // This handles the swipe refered to in the xaml file.
        void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // Handle the swipe
                    break;
                case SwipeDirection.Right:
                    // Handle the swipe
                    break;
                case SwipeDirection.Up:
                    // Handle the swipe
                    break;
                case SwipeDirection.Down:
                    // Handle the swipe
                    break;
            }
        }

    }
}