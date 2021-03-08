using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Written by Shannon Tetley, n6255078
/// </summary>

namespace Picolo.Models
{
    public class Question : Quiz
    {
        // Constructor
        //public Question(string QuizID) : base(QuizID) { }
        public string Text { get; set; }
        public string ID { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string Correct { get; set; }
        public int Exp { get; set; }

    }
}
