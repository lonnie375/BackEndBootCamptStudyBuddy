using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddyApp.Models
{
    public partial class FavoriteQa
    {
        [Key]
        public int FavoriteQAId { get; set; }
        public int UserId { get; set; }
        public int QAId { get; set; }
        public bool IsActive { get; set; }
    }
}
