using Picolo.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Picolo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeSelectionPage : ContentPage
    {
        //public static bool CheckBox1 { get; set; }
        //public static bool CheckBox2 { get; set; }

        public ThemeSelectionPage()
        {
            InitializeComponent();
        }


        async void Theme1Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["theme"] = "Orange";

            if (Application.Current.Properties.ContainsKey("theme"))
            {
                string GetTheme = Application.Current.Properties["theme"] as string;
                Theme theme = Theme.Orange;
                if (GetTheme.Equals("Cyan"))
                {
                    theme = Theme.Cyan;

                }
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (mergedDictionaries != null)
                {
                    mergedDictionaries.Clear();

                    switch (theme)
                    {
                        case Theme.Cyan:
                            mergedDictionaries.Add(new CyanTheme());
                            break;
                        case Theme.Orange:
                        default:
                            mergedDictionaries.Add(new OrangeTheme());
                            break;
                    }
                    // statusLabel.Text = $"{theme.ToString()} theme loaded. Close this page.";
                }
                // do something with id
            }
            else
            {

                //     Application.Current.Properties["theme"] = Theme.Light;

            }
        }

        async void Theme2Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["theme"] = "Cyan";

            if (Application.Current.Properties.ContainsKey("theme"))
            {
                string GetTheme = Application.Current.Properties["theme"] as string;
                Theme theme = Theme.Orange;
                if (GetTheme.Equals("Cyan"))
                {
                    theme = Theme.Cyan;

                }
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (mergedDictionaries != null)
                {
                    mergedDictionaries.Clear();

                    mergedDictionaries.Add(new CyanTheme());
                }
            }
        }
    }
}