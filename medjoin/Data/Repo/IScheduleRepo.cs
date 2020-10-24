using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface IScheduleRepo
    {
        IEnumerable<Schedule> GetSchedules();
        void CreateSchedule(Schedule schedule);
    }
}
