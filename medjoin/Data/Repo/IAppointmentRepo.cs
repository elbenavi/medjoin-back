using medjoin.Dto;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface IAppointmentRepo
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<AppointmentUserMedicalReportDto> GetAppointmentsUserById(int id);
        IEnumerable<Appointment> GetAppointmentsUserDoctorById(int id);
        void CreateAppointment(Appointment Appointment);

        Appointment GetAppointment(Appointment appointment);
    }
}
