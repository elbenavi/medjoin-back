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
    public class AppointmentRepoImpl : IAppointmentRepo
    {
        public Context _context { get; }

        public AppointmentRepoImpl(Context context)
        {
            _context = context;
        }
        public void CreateAppointment(Appointment Appointment)
        {
            _context.Appointments.Add(Appointment);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _context.Appointments.ToList();
        }

        public IEnumerable<AppointmentUserMedicalReportDto> GetAppointmentsUserById(int id)
        {
            // return _context.Appointments.Where(a => a.UserId == id).Include(m => m.Doctor).ToList();
            var appointments = _context.Appointments.Where(a => a.UserId == id).Select(app => new AppointmentUserMedicalReportDto
            {
                Id = app.Id,
                PreferredDate = app.PreferredDate,
                endAppoinment = app.endAppoinment,
                Reason = app.Reason,
                UserId = app.UserId,
                Doctor = app.Doctor,
                MedicalReports = app.MedicalReportAppointments.Select(m => m.MedicalReport).ToList()
            }).OrderByDescending(b => b.PreferredDate).ToList();

            return appointments;
        }

        public IEnumerable<Appointment> GetAppointmentsUserDoctorById(int id)
        {
            return _context.Appointments.Where(a => a.DoctorId == id).Include(m => m.User).OrderByDescending(b => b.PreferredDate).ToList();
        }

        public Appointment GetAppointment(Appointment appointment)
        {
            return _context.Appointments.FirstOrDefault(a => a.UserId == appointment.UserId && a.PreferredDate == appointment.PreferredDate && a.endAppoinment == appointment.endAppoinment);
        }
    }
}
