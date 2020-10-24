using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class DoctorSpecializationRepoImpl : IDoctorSpecialization
    {
        public Context _context { get; }

        public DoctorSpecializationRepoImpl(Context context)
        {
            _context = context;
        }
        public void CreateDoctorSpecialization(DoctorSpecialization DoctorSpecialization)
        {
            _context.DoctorSpecializations.Add(DoctorSpecialization);
            _context.SaveChanges();
        }

        public IEnumerable<DoctorSpecialization> GetDoctorSpecializations()
        {
            return _context.DoctorSpecializations.ToList();
        }
    }
}
