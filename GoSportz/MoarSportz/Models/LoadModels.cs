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

        // Foreign Key
        public string AspNetUserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public TimeSpan Duration { get; set; }
        public Decimal Load { get; set; }
        public int PerceivedExertionRating { get; set; } // Session RPE - Rating of Perceived Exertion

        [ForeignKey("AspNetUserId")]
        public virtual ApplicationUser AspNetUser { get; set; }
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