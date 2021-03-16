using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Project1.Models.ViewModels
{
    public class AppointmentsListViewModel
    {
        public IEnumerable<Appointment> Booked { get; set; }
        public IEnumerable<Appointment> Available { get; set; }
    }
}
