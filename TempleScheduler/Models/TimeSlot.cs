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
        [Required]
        [Key]
        public int TimeSlotId { get; set; }

        //null Group = available time slot
        public Group? Group { get; set; }
        public int? GroupId { get; set; }

        //yyyy-mm-dd
        public string Date { get; set; }
        public int Time { get; set; }

    }
}
