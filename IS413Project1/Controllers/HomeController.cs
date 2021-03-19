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
        //This is the Home Controller
        //private readonly ILogger<HomeController> _logger;
        //private ITempleRepository _repository;

        //These will help to join the tables to output all in info
        //List<Appointment> appointmentData = new List<Appointment>();
        //List<Signup> signupData = new List<Signup>();

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

            return RedirectToAction("SignupForm", new { appointmentId = appointmentId });

        }

        public IActionResult AllAppointments()
        {
            return View(context.Signups.Where(x => x.BeginTime != null));
           
        }

       
        [HttpGet]

        public IActionResult SignupForm(int appointmentId)
        {
            //This is passing the appointment Id so that we can link the two models
            Appointment appointment = context.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefault();

            ViewBag.Appointment = appointment;

            return View();
        }

        [HttpPost]
        public IActionResult SignupForm(Signup s, int appointmentId)
        {
            //Update the database
            context.Signups.Add(s);
            context.SaveChanges();

            //This is grabbing where the context.appointments is equal to the ID so that we can assign the info
            var AssignedAppointment = context.Appointments.Where(x => x.AppointmentId == appointmentId).FirstOrDefault();

            AssignedAppointment.SignupId = s.SignupId;
            s.BeginTime = AssignedAppointment.BeginTime;
            //AssignedAppointment.BeginTime = context.Signups.Where(s => s.SignupId == mostRecentSignUp).FirstOrDefault().BeginTime;
                
            context.SaveChanges();
            return View("Index");
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
