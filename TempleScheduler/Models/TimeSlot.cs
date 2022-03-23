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

        public Group Group { get; set; }
        public int GroupId { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }

    }
}
