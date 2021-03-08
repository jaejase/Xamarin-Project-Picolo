// Written by Minseong (Jason) Kim N10218807

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Picolo.Models
{
    public class User
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PersonalExperience { get; set; }
        public int PartyExperience { get; set; }
        public string HatColour { get; set; }

        //statistics
        public int QuestionsAnswered { get; set; }
        public int QuestsCompleted { get; set; }
        public int CommentsPosted { get; set; }
        public int AverageQuizAccuracy { get; set; }
        public int AverageTimeTakenEachActivity { get; set; }

        //trophygained
        public bool Trophy1Gained { get; set; }
        public bool Trophy2Gained { get; set; }
        public bool Trophy3Gained { get; set; }
        public bool Trophy4Gained { get; set; }
        public bool Trophy5Gained { get; set; }
        public bool Trophy6Gained { get; set; }
        public bool Trophy7Gained { get; set; }
        public bool Trophy8Gained { get; set; }
        public bool Trophy9Gained { get; set; }
        
        //levels
        public int MyPicoloLevel { get; set; }
        public int MyPartyLevel { get; set; }
    }
}
