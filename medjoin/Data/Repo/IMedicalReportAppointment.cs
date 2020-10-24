using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface IMedicalReportAppointment
    {
        IEnumerable<MedicalReportAppointment> GetMedicalReportAppointments();
        // IEnumerable<MedicalReportAppointment> GetMedicalReportAppointments(int idMedicalReport, int );
        void CreateMedicalReportAppointment(MedicalReportAppointment MedicalReportAppointment);
    }
}
