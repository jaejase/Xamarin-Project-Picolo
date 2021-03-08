using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Picolo.Models;
using Picolo.ViewModels;

namespace Picolo.Views
{
    public partial class QuestSummary : ContentPage
    {
        public QuestSummary()
        {
            InitializeComponent();
            BindingContext = new QuestSummaryViewModel();
        }
    }
}