using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using medjoin.Data.Repo;
using medjoin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace medjoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalDetailController : ControllerBase
    {
        private readonly IMedicalDetailRepo _repo;

        public MedicalDetailController(IMedicalDetailRepo repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<MedicalDetail>> GetMedicalDetails()
        {
            var MedicalDetails = _repo.GetMedicalDetails();
            return Ok(MedicalDetails);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateMedicalDetail(MedicalDetail MedicalDetail)
        {
            _repo.CreateDoctorMedicalDetail(MedicalDetail);
            return NoContent();
        }
    }
}