using System;
using System.Collections.Generic;

namespace StudyBuddyApp.Models
{
    public partial class QuestionAndAnswerDetail
    {
        public int Qaid { get; set; }
        public string Qacategory { get; set; } = null!;
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}
