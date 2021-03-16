using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//allows us to query in db
namespace IS413Project1.Models
{
    public interface ITempleRepository
    {
        IQueryable<Appointment> Appointments { get; }
        IQueryable<Signup> Signups { get; }
    }
}
