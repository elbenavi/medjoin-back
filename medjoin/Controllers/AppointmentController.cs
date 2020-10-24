using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medjoin.Data.Repo;
using medjoin.Dto;
using medjoin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medjoin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo _repo;

        public AppointmentController(IAppointmentRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _repo.GetAppointments().ToList();
        }

        [HttpGet("{id}")]
        public IEnumerable<AppointmentUserMedicalReportDto> GetAppointmentsUserById(int id)
        {
            return _repo.GetAppointmentsUserById(id).ToList();
        }

        [HttpGet("doctor/{id}")]
        public IEnumerable<Appointment> GetAppointmentsUserDoctorById(int id)
        {
            return _repo.GetAppointmentsUserDoctorById(id).ToList();
        }

        [HttpPost]
        public ActionResult<Appointment> CreateAppointment(Appointment Appointment)
        {
            _repo.CreateAppointment(Appointment);
            var appoinmentTemp = _repo.GetAppointment(Appointment);
            if(appoinmentTemp == null)
            {
                return NotFound();
            }
            return Ok(appoinmentTemp);
            
        }
    }
}