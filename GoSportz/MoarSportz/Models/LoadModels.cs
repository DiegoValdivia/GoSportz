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
        public string AthleteId { get; set; }

        [ForeignKey("AthleteId")]
        public virtual ApplicationUser User { get; set; }
    }
}