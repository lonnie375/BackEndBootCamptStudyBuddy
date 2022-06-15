using System;
using System.Collections.Generic;

namespace StudyBuddyApp.Models
{
    public partial class FavoriteQa
    {
        public int FavoriteQaid { get; set; }
        public int UserId { get; set; }
        public int Qaid { get; set; }
        public bool IsActive { get; set; }
    }
}
