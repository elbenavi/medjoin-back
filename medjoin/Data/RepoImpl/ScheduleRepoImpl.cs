using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class ScheduleRepoImpl : IScheduleRepo
    {
        public Context _context { get; }

        public ScheduleRepoImpl(Context context)
        {
            _context = context;
        }

        public IEnumerable<Schedule> GetSchedules()
        {
            return _context.Schedules.ToList();
        }

        public void CreateSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }
    }
}
