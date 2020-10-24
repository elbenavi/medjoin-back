using medjoin.Data.Repo;
using medjoin.Dto;
using medjoin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class DoctorRepoImpl : IDoctorRepo
    {
        public Context _context { get; }

        public DoctorRepoImpl(Context context)
        {
            _context = context;
        }
        public void CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public IEnumerable<DoctorReadDto> GetDoctors()
        {
            var doctors = _context.Doctors.Select(d => new DoctorReadDto
            {
                Id = d.Id,
                Specializations = d.DoctorSpecializations.Select(s => s.Specializations).ToList(),
                Description = d.Description,
                Rate = d.Rate,
                Schedule = d.DoctorShedules.Select(sc => sc.Schedule).ToList(),
                Tags = d.DoctorTags.Select(t => t.Tag).ToList()
            }).ToList();

            return doctors;
        }
    }
}
