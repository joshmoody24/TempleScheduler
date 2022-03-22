using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    // only one timeslot per hour
    // only one group per timeslot
    public class TimeSlot
    {
        //Not sure what the best way to store time information

        // OPTION 1: a datetime variable
        /*
        [Required]
        public DateTime time;
        */

        // OPTION 2: using a string for date, and an int for hour
        /*
        [Required]
        // yyyy-mm-dd
        public string day;
        // hour represents hour of the day, 8 = 8AM, 12 = 12PM, 20 = 8PM etc.
        [Range(8,20)]
        public byte hour;
        */

        [Required]
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }

    }
}
