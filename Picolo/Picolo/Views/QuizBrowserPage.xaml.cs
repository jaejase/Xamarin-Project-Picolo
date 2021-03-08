using System;
using Picolo.Services;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Picolo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Picolo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizBrowserPage : ContentPage
    {
        public QuizBrowserPage()
        {
            InitializeComponent();
            // May be possible to bind a particulay field to a new binding.
            this.BindingContext = new QuizBrowserViewModel();
        }

        // This handles the swipe refered to in the xaml file.
        // Keeping this code for reference.
        //void OnSwiped(object sender, SwipedEventArgs e)
        //{
        //    switch (e.Direction)
        //    {
        //        case SwipeDirection.Left:
        //            // Handle the swipe
        //            break;
        //        case SwipeDirection.Right:
        //            // Handle the swipe
        //            break;
        //        case SwipeDirection.Up:
        //            // Handle the swipe
        //            break;
        //        case SwipeDirection.Down:
        //            // Handle the swipe
        //            break;
        //    }
        //}

    }

}