using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// This page is not used because a redesign of the app was done due 
/// to the database not working.
/// </summary>

namespace Picolo.Models
{
    public class QuizAttempt : Quiz
    {
        // Constructor
        //public QuizAttempt(string QuizID) : base(QuizID) { }

        // Record of how much time has been used. Ends attempt if expired.
        public DateTime TimeUsed { get; set; }
        // A list of numbers representing which choice was selected.
        // Controlled by radial buttons.
        public List<int> Answers { get; set; }
        // Indicates if the quiz is completed, force true if time is over.
        public Boolean IsComplete { get; set; }
        // Total Exp earned from correct answers.
        public int Exp { get; set; }
        // Number of correct answers
        public int Score { get; set; }

    }
}
