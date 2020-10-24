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
    public class DoctorSpecializationController : ControllerBase
    {
        private readonly IDoctorSpecialization _repo;

        public DoctorSpecializationController(IDoctorSpecialization repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<DoctorSpecialization>> GetDoctorSpecializations()
        {
            var doctorSpecializations = _repo.GetDoctorSpecializations();
            return Ok(doctorSpecializations);
        }

        [HttpPost]
        public ActionResult CreateDoctorSpecialization(DoctorSpecialization doctorSpecialization)
        {
            _repo.CreateDoctorSpecialization(doctorSpecialization);
            return NoContent();
        }
    }
}