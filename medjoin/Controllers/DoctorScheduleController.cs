using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medjoin.Data.Repo;
using medjoin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medjoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorSchedule _repo;

        public DoctorScheduleController(IDoctorSchedule repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<DoctorShedule>> GetDoctorShedules()
        {
            var doctorShedules = _repo.GetDoctorShedules();
            return Ok(doctorShedules);
        }

        [HttpPost]
        public ActionResult CreateDoctorShedule(DoctorShedule doctorShedule)
        {
            _repo.CreateDoctorShedule(doctorShedule);
            return NoContent();
        }
    }
}