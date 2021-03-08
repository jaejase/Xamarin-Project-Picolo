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
    public partial class QuestLog : ContentPage
    {
        public object Quests { get; set; }

        public QuestLog()
        {
            InitializeComponent();
            this.BindingContext = new QuestLogViewModel();  
        }
    }
}