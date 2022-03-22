using System;
using Microsoft.EntityFrameworkCore;

namespace TempleScheduler.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }


        //seeding data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Group>().HasData(
                new Group
                {
                    AppointmentId = 1,
                    GroupName = "4-1",
                    GroupSize = "4",
                    Email = "group4-1@gmail.com",
                    Phone = "123-456-7890",
                    Time = "12",
                    Date = "1/1/2022"
                },
                new Group
                {
                    AppointmentId = 2,
                    GroupName = "4-2",
                    GroupSize = "5",
                    Email = "group4-2@gmail.com",
                    Phone = "111-222-3333",
                    Time = "15",
                    Date = "1/2/2022"
                },
                new Group
                {
                    AppointmentId = 3,
                    GroupName = "4-3",
                    GroupSize = "6",
                    Email = "group4-3@gmail.com",
                    Phone = "555-555-5555",
                    Time = "11",
                    Date = "1/3/2022"
                }
            );
        }
    }

}
