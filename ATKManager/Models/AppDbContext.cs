using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATKManager.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtScheduleItem> CourtScheduleItem { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<FullCalendar> FullCalendars { get; set; }
    }
}
