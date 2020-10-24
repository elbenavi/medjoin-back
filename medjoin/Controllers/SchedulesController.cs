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
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleRepo _repo;

        public SchedulesController(IScheduleRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Schedule>> GetSchedules()
        {
            var schedules = _repo.GetSchedules();
            return Ok(schedules);
        }

        [HttpPost]
        public ActionResult CreateSchedule(Schedule schedule)
        {
            _repo.CreateSchedule(schedule);
            return NoContent();
        }
    }
}