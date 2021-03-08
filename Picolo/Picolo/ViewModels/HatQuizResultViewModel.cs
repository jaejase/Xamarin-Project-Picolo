// Written by Aaron Hayton N9946977
using Picolo.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Picolo.ViewModels
{
    class HatQuizResultViewModel : BaseViewModel
    {
        // Continue to group selection 
        public Command ChooseGroup { get; }
        public string HatResult { get; set; }
        public string HatDescription { get; set; }
        public string HatImg { get; set; }
        public HatQuizResultViewModel()
        {
            Title = "Six Hat Survey Result";
            ChooseGroup = new Command(OnGroupClicked);
            DisplayResult();
        }
        public async void OnGroupClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(PartySelection)}");
        }
        public async void DisplayResult()
        {
            var user = await UserDataStore.GetItemAsync("User1");
            HatResult = user.HatColour;
            DisplayDescription();
        }
        public void DisplayDescription()
        {
            if (HatResult == "Red")
            {
                HatDescription = "You look at problems using your intuition, gut reaction, and emotion. Also, think how others could react emotionally. Try to understand the responses of people who do not fully know your reasoning.";
                HatImg = "red_hat.png";
            }
            else if (HatResult == "White") { 
                HatDescription = "You focus on the available data. Look at the information that you have, analyze past trends, and see what you can learn from it. Look for gaps in your knowledge, and try to either fill them or take account of them.";
                HatImg = "white_hat.png";
            }
            else if (HatResult == "Black") { 
                HatDescription = "You look at a decision's potentially negative outcomes. Look at it cautiously and defensively. Try to see why it might not work. This is important because it highlights the weak points in a plan. It allows you to eliminate them, alter them, or prepare contingency plans to counter them.";
                HatImg = "black_hat.png";
            }
            else if (HatResult == "Green") { 
                HatDescription = "You develop creative solutions to a problem. It is a freewheeling way of thinking, in which there is little criticism of ideas. (You can explore a range of creativity tools to help you.)";
                HatImg = "green_hat.png";
            }
            else if (HatResult == "Blue") { 
                HatDescription = "This hat represents process control. It's the hat worn by people chairing meetings, for example. When facing difficulties because ideas are running dry, they may direct activity into Green Hat thinking. When contingency plans are needed, they will ask for Black Hat thinking.";
                HatImg = "blue_hat.png";
            }
            else if (HatResult == "Yellow") { 
                HatDescription = "This hat helps you to think positively. It is the optimistic viewpoint that helps you to see all the benefits of the decision and the value in it. Yellow Hat thinking helps you to keep going when everything looks gloomy and difficult.";
                HatImg = "yellow_hat.png";
            }
        }
    }
}
