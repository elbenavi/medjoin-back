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
    public class EspecialitationController : ControllerBase
    {
        private readonly IEspecialitationRepo _repo;

        public EspecialitationController(IEspecialitationRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Specialization>> GetTags()
        {
            var espetialitations = _repo.GetEspecialitations();
            return Ok(espetialitations);
        }

        [HttpPost]
        public ActionResult CreateTag(Specialization espetialitation)
        {
            _repo.CreateEspecialitation(espetialitation);
            return NoContent();
        }
    }
}