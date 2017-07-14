using Microsoft.AspNet.Identity;
using System;

namespace MoarSportz.Models
{
    public class LoadEntry
    {
        public LoadEntry() // Verify
        { }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public TimeSpan Duration { get; set; }
        public Decimal Load { get; set; }
        public int PerceivedExertionRating { get; set; } // Session RPE - Rating of Perceived Exertion

        // Foreign key
        public int AthleteId { get; set; } // use user Id
        
        // Navigation property
        public virtual IUser Athlete { get; set; }
    }
}