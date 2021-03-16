using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Project1.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string BeginTime { get; set; }

        [Required]
        public string EndTime { get; set; }
        public string Description { get; set; }
        [Required]
        public bool Booked { get; set; }



    }
}
