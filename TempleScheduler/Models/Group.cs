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

        [Required]
        public string Name { get; set; }

        [Range(1,15)]
        public string Size { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
