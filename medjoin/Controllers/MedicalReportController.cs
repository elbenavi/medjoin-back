using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using medjoin.Data.RepoImpl;
using medjoin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace medjoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalReportController : ControllerBase
    {
        private readonly IMedicalReportRepo _repo;

        public MedicalReportController(IMedicalReportRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MedicalReport>> GetMedicalReports(int id)
        {
            var MedicalReport = _repo.GetMedicalReportsByUserId(id);
            return Ok(MedicalReport);
        }

        [HttpPost]
        public ActionResult CreateDoctorShedule(MedicalReport MedicalReport)
        {
            _repo.CreateMedicalReports(MedicalReport);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDoctorShedule(int id)
        {
            var medicalReport = _repo.GetMedicalReportsById(id);
            if(medicalReport == null)
            {
                return NotFound();
            }
            _repo.DeleteMedicalReports(medicalReport);
            var folderName = Path.Combine("Resources", "Files", "user"+medicalReport.UserId);
            try
            {
                var fileName = folderName + "/" + medicalReport.UrlResource;
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
            }
            catch (IOException ioExp)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("upload/{id}"), DisableRequestSizeLimitAttribute]
        public IActionResult Upload(int id)
        {
            try
            {
                var file = Request.Form.Files[0];
                var directoryName = "user" + id;
                
                var folderName = Path.Combine("Resources", "Files");
                Directory.CreateDirectory(folderName + "/" + directoryName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName, directoryName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}