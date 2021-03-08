// Written by Mia Basta N10246771

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;

namespace Picolo.Models
{
    public class Quest
    {
        public string Id { get; set; }
        public string Type { get; set; } //quest OR daily OR assignment
        public string Status { get; set; } //complete OR incomplete
        public string Name { get; set; }
        public string Topic { get; set; }
        public int Experience { get; set; }
        public int QuestResult { get; set; }
        public string QuestResults { get; set; }
        public int NumQuestions { get; set; }
        public DateTime QuestDate { get; set; }

        public string Icon {get; set;}
        public string QuestColor { get; set; }
    }
}
