using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class DoctorScheduleRepoImpl: IDoctorSchedule
    {
        public Context _context { get; }

        public DoctorScheduleRepoImpl(Context context)
        {
            _context = context;
        }

        public IEnumerable<DoctorShedule> GetDoctorShedules()
        {
            return _context.DoctorShedule.ToList();
        }

        public void CreateDoctorShedule(DoctorShedule DoctorShedule)
        {
            _context.DoctorShedule.Add(DoctorShedule);
            _context.SaveChanges();
        }
    }
}
