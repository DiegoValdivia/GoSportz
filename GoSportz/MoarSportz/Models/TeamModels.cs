using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoarSportz.Models
{
    public class Coach
    {
        [Key]
        public int CoachId { get; set; }

        // Foreign Key
        public string AspNetUser { get; set; }

        [ForeignKey("AspNetUser")]
        public virtual ApplicationUser User { get; set; }
    }

    public class Athlete
    {
        [Key]
        public int AthleteId { get; set; }

        // Foreign Key
        public string AspNetUser { get; set; }

        [ForeignKey("AspNetUser")]
        public virtual ApplicationUser User { get; set; }
    }

    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        //public string Name { get; set; }

        // Nullable Foreign Key
        public int? Athlete { get; set; }

        // Nullable Foreign Key
        public int? Coach { get; set; }

        [ForeignKey("Athlete")]
        public virtual Athlete Player { get; set; }

        [ForeignKey("Coach")]
        public virtual Coach Admin { get; set; }
    }
}