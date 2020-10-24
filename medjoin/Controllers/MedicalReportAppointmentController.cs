using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medjoin.Data.Repo;
using medjoin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medjoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalReportAppointmentController : ControllerBase
    {
        private readonly IMedicalReportAppointment _repo;

        public MedicalReportAppointmentController(IMedicalReportAppointment repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<MedicalReportAppointment>> GeMedicalReportAppointments()
        {
            var MedicalReportAppointment = _repo.GetMedicalReportAppointments();
            return Ok(MedicalReportAppointment);
        }

        [HttpPost]
        public ActionResult CreateDoctor(MedicalReportAppointment MedicalReportAppointment)
        {
            _repo.CreateMedicalReportAppointment(MedicalReportAppointment);
            return NoContent();
        }
    }
}