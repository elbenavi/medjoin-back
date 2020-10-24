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
    public class DoctorTagController : ControllerBase
    {
        private readonly IDoctorTagRepo _repo;

        public DoctorTagController(IDoctorTagRepo repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<DoctorTag>> GetDoctorTags()
        {
            var doctorTags = _repo.GetDoctorTags();
            return Ok(doctorTags);
        }

        [HttpPost]
        public ActionResult CreateDoctor(DoctorTag doctorTag)
        {
            _repo.CreateDoctorTag(doctorTag);
            return NoContent();
        }
    }
}