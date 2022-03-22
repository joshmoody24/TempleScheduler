using System;
using Microsoft.EntityFrameworkCore;

namespace TempleScheduler.Models
{
    public class AppointmentContext: DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {

        }
        public DbSet<AppointmentContext> Appointments { get; set; }
    }
}
