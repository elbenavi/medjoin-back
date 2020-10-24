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
    public class TagsController : ControllerBase
    {
        private readonly ITagRepo _repo;

        public TagsController(ITagRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tag>> GetTags()
        {
            var tags = _repo.GetTags();
            return Ok(tags);
        }

        [HttpPost]
        public ActionResult CreateTag(Tag tag)
        {
            _repo.CreateTags(tag);
            return NoContent();
        }
    }
}