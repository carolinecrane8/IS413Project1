using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Project1.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            TempleDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TempleDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Appointments.Any())
            {
                context.Appointments.AddRange(

                    new Appointment
                    {
                        AppointmentId = 1,
                        BeginTime = "2021-03-21 8:00:00",
                        Description = "Full Tour: Walk the perimeter of the site, sturdy shoes recommended.",

                    },
                    new Appointment
                    {
                        AppointmentId = 2,
                        BeginTime = "2021-03-21 8:00:00",
                        Description = "Full Tour: Walk the perimeter of the site, sturdy shoes recommended.",
                    }


                    );
                context.SaveChanges();
            }
        }
    }
}
