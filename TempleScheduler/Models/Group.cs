using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    public class Group
    {
        [Required]
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Enter the Group Name")]
        public string GroupName { get; set; }

        [Required]
        [Range(1,15, ErrorMessage = "Group size should be in 1 -15")]
        public string GroupSize { get; set; }

        [Required(ErrorMessage ="Enter the Email Address")]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
