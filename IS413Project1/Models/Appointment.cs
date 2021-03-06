using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Project1.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }

        public int? SignupId { get; set; }

        [Required]
        [Column(TypeName = "smalldatetime")]
        public string BeginTime { get; set; }

        [Required]
        public string Description { get; set; }



    }
}
