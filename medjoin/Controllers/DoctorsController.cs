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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepo _repo;

        public DoctorsController(IDoctorRepo repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        public ActionResult<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = _repo.GetDoctors();
            return Ok(doctors);
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            _repo.CreateDoctor(doctor);
            return NoContent();
        }
    }
}