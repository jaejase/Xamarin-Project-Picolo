using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.Models
{
    public class Quiz
    {
        // Constructor
        //public Quiz(string QuizID) { }
       
        [PrimaryKey]
        public string QuizID { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public int TotalExp { get; set; }
        // The date of the quiz. 
        // Call with the syntax: variable = DateOf.Date;
        public DateTime DateOf { get; set; }
        // int representing number of minutes allowed for quiz.
        public int TimeLimit { get; set; }
        // Just call this variable if total score is needed.
        public int NumQuestions { get; set; }

    }
}
