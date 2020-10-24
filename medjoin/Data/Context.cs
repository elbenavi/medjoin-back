using medjoin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Specialization> Especialitations { get; set; }
        public DbSet<Schedule> Schedules{ get; set; }
        public DbSet<DoctorTag> DoctorTags { get; set; }
        public DbSet<DoctorShedule> DoctorShedule { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MedicalDetail> MedicalDetails { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<MedicalReportAppointment> medicalReportAppointments{ get; set; }
    }
}
