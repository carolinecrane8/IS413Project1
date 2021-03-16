using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Project1.Models
{
    public class EFTempleRepository : ITempleRepository
    {
        private TempleDbContext _context;

        //contructor
        public EFTempleRepository (TempleDbContext context)
        {
            _context = context;
        }
        public IQueryable<Appointment> Appointments => _context.Appointments;
        public IQueryable<Signup> Signups => _context.Signups;

    }
}
