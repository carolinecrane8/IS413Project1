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

        private TempleDbContext context { get; set; }
        public HomeController(TempleDbContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AvailAppointments()
        {
            //Should be able to query and figure out where appointments == booked =true
            //This is what I did before adding view model
            //return View(context.Appointments);
            return View(new AppointmentsListViewModel
            {
               Booked = context.Appointments
                .Where(x => x.Booked == false)
            }
              );
        }

        public IActionResult AllAppointments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignupForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignupForm(Signup s, Appointment a)
        {
            //That required information is entered and validation model works
            if (ModelState.IsValid)
            {
                context.Signups.Add(s);
                Response.Redirect("AllAppointments");
                return View();
            }
            else
            {
                return View();
            }
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
