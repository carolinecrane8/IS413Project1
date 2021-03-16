using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Project1.Models
{
    public class TempleDbContext: DbContext
    {
        public TempleDbContext (DbContextOptions<TempleDbContext> options): base (options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Signup> Signups { get; set; }
    }

    
}
