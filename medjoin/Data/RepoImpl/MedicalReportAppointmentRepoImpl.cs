using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class MedicalReportAppointmentRepoImpl : IMedicalReportAppointment
    {
        public Context _context { get; }

        public MedicalReportAppointmentRepoImpl(Context context)
        {
            _context = context;
        }
        public void CreateMedicalReportAppointment(MedicalReportAppointment MedicalReportAppointment)
        {
            _context.medicalReportAppointments.Add(MedicalReportAppointment);
            _context.SaveChanges();
        }

        public IEnumerable<MedicalReportAppointment> GetMedicalReportAppointments()
        {
            return _context.medicalReportAppointments.ToList();
        }
    }
}
