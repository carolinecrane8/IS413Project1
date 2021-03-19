using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//another cute view model... doing it's thang connecting the view and models
namespace IS413Project1.Models.ViewModels
{
    public class JoinDataViewModel
    {
        public Appointment appointmentVm { get; set; }
        public Signup signupVm { get; set; }
    }
}
