using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoarSportz.Models
{
    public class LoadEntry
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public TimeSpan Duration { get; set; }
        public Decimal Load { get; set; }
        public int PerceivedExertionRating { get; set; } // Session RPE - Rating of Perceived Exertion

        // Foreign key
        public int AthleteId { get; set; }

        [ForeignKey("AthleteId")]
        public virtual Athlete Athlete { get; set; }
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
}