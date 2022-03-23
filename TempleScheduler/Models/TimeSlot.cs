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

        public int AppointmentId { get; set; }
        public Group Group { get; set; }

        [Required(ErrorMessage ="The Date Format is mm/dd/yyyy")]
        // yyyy-mm-dd
        public string Date;

        // hour represents hour of the day, 8 = 8AM, 12 = 12PM, 20 = 8PM etc.
        [Range(8,20, ErrorMessage ="The available time is from 8-20")]
        public string Hour;
       

        //[Required]
        //[ForeignKey("Group")]
        //public int AppointmentID { get; set; }
        //public Group Group { get; set; }

    }
}
