using System;
using System.Collections.Generic;
using System.Linq;
using Scheduler.Model;
using Scheduler.Model.Entities;

namespace Scheduler.Data
{
    public class SchedulerDbInitializer
    {
        private static SchedulerContext _context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (SchedulerContext)serviceProvider.GetService(typeof(SchedulerContext));

            InitializeSchedules();
        }

        private static void InitializeSchedules()
        {
            if (!_context.Users.Any())
            {
                var user01 = new User { Name = "Chris Sakellarios", Profession = "Developer", Avatar = "avatar_02.png" };

                var user02 = new User { Name = "Charlene Campbell", Profession = "Web Designer", Avatar = "avatar_03.jpg" };

                var user03 = new User { Name = "Mattie Lyons", Profession = "Engineer", Avatar = "avatar_05.png" };

                var user04 = new User { Name = "Kelly Alvarez", Profession = "Network Engineer", Avatar = "avatar_01.png" };

                var user05 = new User { Name = "Charlie Cox", Profession = "Developer", Avatar = "avatar_03.jpg" };

                var user06 = new User { Name = "Megan	Fox", Profession = "Hacker", Avatar = "avatar_05.png" };

                _context.Users.Add(user01); _context.Users.Add(user02);
                _context.Users.Add(user03); _context.Users.Add(user04);
                _context.Users.Add(user05); _context.Users.Add(user06);

                _context.SaveChanges();
            }

            if (!_context.Schedules.Any())
            {
                var schedule01 = new Schedule
                {
                    Title = "Meeting",
                    Description = "Meeting at work with the boss",
                    Location = "Korai",
                    CreatorId = 1,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Work,
                    TimeStart = DateTime.Now.AddHours(4),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee { ScheduleId = 1, UserId = 2 },
                        new Attendee { ScheduleId = 1, UserId = 3 },
                        new Attendee { ScheduleId = 1, UserId = 4 }
                    }
                };

                var schedule02 = new Schedule
                {
                    Title = "Coffee",
                    Description = "Coffee with folks",
                    Location = "Athens",
                    CreatorId = 2,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Coffee,
                    TimeStart = DateTime.Now.AddHours(3),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee { ScheduleId = 2, UserId = 1 },
                        new Attendee { ScheduleId = 1, UserId = 3 },
                        new Attendee { ScheduleId = 2, UserId = 4 }
                    }
                };

                var schedule03 = new Schedule
                {
                    Title = "Shopping day",
                    Description = "Shopping therapy",
                    Location = "Attica",
                    CreatorId = 3,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Shopping,
                    TimeStart = DateTime.Now.AddHours(3),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee { ScheduleId = 3, UserId = 1 },
                        new Attendee { ScheduleId = 3, UserId = 4 },
                        new Attendee { ScheduleId = 3, UserId = 5 }
                    }
                };

                var schedule04 = new Schedule
                {
                    Title = "Family",
                    Description = "Thanks giving day",
                    Location = "Home",
                    CreatorId = 5,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(3),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee { ScheduleId = 4, UserId = 1 },
                        new Attendee { ScheduleId = 4, UserId = 2 },
                        new Attendee { ScheduleId = 4, UserId = 5 }
                    }
                };

                var schedule05 = new Schedule
                {
                    Title = "Friends",
                    Description = "Friends giving day",
                    Location = "Home",
                    CreatorId = 5,
                    Status = ScheduleStatus.Cancelled,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(5),
                    TimeEnd = DateTime.Now.AddHours(7),
                    Attendees = new List<Attendee>
                    {
                        new Attendee { ScheduleId = 4, UserId = 1 },
                        new Attendee { ScheduleId = 4, UserId = 2 },
                        new Attendee { ScheduleId = 4, UserId = 3 },
                        new Attendee { ScheduleId = 4, UserId = 4 },
                        new Attendee { ScheduleId = 4, UserId = 5 }
                    }
                };

                var schedule06 = new Schedule
                {
                    Title = "Meeting with the boss and collegues",
                    Description = "Discuss project planning",
                    Location = "Office",
                    CreatorId = 3,
                    Status = ScheduleStatus.Cancelled,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(22),
                    TimeEnd = DateTime.Now.AddHours(30),
                    Attendees = new List<Attendee>
                    {
                        new Attendee { ScheduleId = 4, UserId = 1 },
                        new Attendee { ScheduleId = 4, UserId = 2 },
                        new Attendee { ScheduleId = 4, UserId = 5 }
                    }
                };

                var schedule07 = new Schedule
                {
                    Title = "Scenario presentation",
                    Description = "Discuss new movie's scenario",
                    Location = "My special place",
                    CreatorId = 6,
                    Status = ScheduleStatus.Cancelled,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(11),
                    TimeEnd = DateTime.Now.AddHours(13),
                    Attendees = new List<Attendee>
                    {
                        new Attendee { ScheduleId = 4, UserId = 4 },
                        new Attendee { ScheduleId = 4, UserId = 2 },
                        new Attendee { ScheduleId = 4, UserId = 3 }
                    }
                };

                _context.Schedules.Add(schedule01); _context.Schedules.Add(schedule02);
                _context.Schedules.Add(schedule03); _context.Schedules.Add(schedule04);
                _context.Schedules.Add(schedule05); _context.Schedules.Add(schedule06);
                _context.Schedules.Add(schedule07);
            }

            _context.SaveChanges();
        }
    }
}
