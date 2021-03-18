using IS413Project1.Models;
using IS413Project1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Project1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private ITempleRepository _repository;

        //These will help to join the tables to output all in info
        List<Appointment> appointmentData = new List<Appointment>();
        List<Signup> signupData = new List<Signup>();

        private TempleDbContext context { get; set; }
        public HomeController(TempleDbContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AvailAppointments()
        {
            //Should be able to query and figure out where appointments == booked =true
            //This is what I did before adding view model

            //ViewBag.Appointmnet = context.Appointments.Where(x => x.SignupId == null);
            return View(new AppointmentsListViewModel
            {
               Available = context.Appointments
                .Where(x => x.SignupId == null)
            }
              );
        }

        [HttpPost]
        public IActionResult AvailAppointments(int appointmentId)
        {
            Appointment appointment = context.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefault();
            
            //Should be able to query and figure out where appointments == booked =true
            //This is what I did before adding view model
            //ViewBag.Appointment = appointment;
            //return View(context.Appointments);
            return RedirectToAction("SignupForm", new { appointmentId = appointmentId });

        }

        public IActionResult AllAppointments()
        {
            return View(new AppointmentsListViewModel
            {
                Booked = context.Appointments
               .Where(x => x.SignupId != null)
            }
             );
            //IEnumerable<> 
            //appointmentData = context.Appointments.Where();
            //var whatever = context.Appointments
            //insertDummyData();
            //var JoinDataViewModel = from a in appointmentData
            //                        join s in signupData on a.AppointmentId equals s.SignupId into sa
            //                        from s in sa.DefaultIfEmpty()
            //                        select new JoinDataViewModel { appointmentVm = a, signupVm = s };
            //return View("AllAppointments");//, JoinDataViewModel);
        }

        //public void insertDummyData()
        //{
        //    signupData.Add(new Signup
        //    {

        //        SignupId = 6,
        //        GroupName = "Jamie's",
        //        GroupSize = 4,

        //    });
        //    appointmentData.Add(new Appointment
        //    {
        //       AppointmentId = 1,
        //        BeginTime = "2021-03-21 9:00:00",
        //        //Duration = 1,
        //        //Description = "sdigjsogn"
        //    });
        //}
        [HttpGet]

        public IActionResult SignupForm(int appointmentId)
        {
            Appointment appointment = context.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefault();

            ViewBag.Appointment = appointment;

            return View();
        }

        [HttpPost]
        public IActionResult SignupForm(Signup s, int appointmentId)
        {
            //That required information is entered and validation model works
            //if (ModelState.IsValid)
            //{
            context.Signups.Add(s);
            context.SaveChanges();

            //This will set the variable most recent sign up to be equal to the signups object that has the highest ID which should make it work better.
            //var mostRecentSignUp = context.Signups.Select(s => s.SignupId).Max();


            var AssignedAppointment = context.Appointments.Where(x => x.AppointmentId == appointmentId).FirstOrDefault();

            AssignedAppointment.SignupId = s.SignupId;
            //AssignedAppointment.BeginTime = context.Signups.Where(s => s.SignupId == mostRecentSignUp).FirstOrDefault().BeginTime;
                
            context.SaveChanges();
            return View("Index");
            //}
            //else {
            //    //ViewBag.Appointment = context.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefault();

            //    //Should be able to query and figure out where appointments == booked =true
            //    //This is what I did before adding view model
            //    //return View(context.Appointments);
            //    return View();
            //}
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
