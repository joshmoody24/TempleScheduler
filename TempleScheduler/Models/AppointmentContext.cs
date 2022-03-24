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
        public DbSet<TimeSlot> TimeSlots { get; set; }

        //seeding data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Group>().HasData(
                new Group
                {
                    GroupId = 1,
                    GroupName = "4-1",
                    GroupSize = "4",
                    Email = "group4-1@gmail.com",
                    Phone = "123-456-7890",
                },
                new Group
                {
                    GroupId = 2,
                    GroupName = "4-2",
                    GroupSize = "5",
                    Email = "group4-2@gmail.com",
                    Phone = "111-222-3333",
                },
                new Group
                {
                    GroupId = 3,
                    GroupName = "4-3",
                    GroupSize = "6",
                    Email = "group4-3@gmail.com",
                    Phone = "555-555-5555",
                }
            );
            /* old code for seeding database
            mb.Entity<TimeSlot>().HasData(
                new TimeSlot
                {
                    TimeSlotId = 1,
                    GroupId = null,
                    Date = "2022-01-01",
                    Time = 12

                },
                new TimeSlot
                {
                    TimeSlotId = 2,
                    GroupId = 2,
                    Date = "2022-01-02",
                    Time = 15

                },
                new TimeSlot
                {
                    TimeSlotId = 3,
                    GroupId = null,
                    Date = "2022-01-03",
                    Time = 11

                },
                new TimeSlot
                {
                    TimeSlotId = 4,
                    GroupId = null,
                    Date = "2022-01-03",
                    Time = 13

                });
            */
        }
    }

}
