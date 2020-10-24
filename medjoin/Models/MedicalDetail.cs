using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class MedicalDetail
    {
        [Key]
        public int Id { get; set; }
        public int YearsOfExperience { get; set; }
        public string ProfessionalDesignation { get; set; }
        public string UrlLicenseCertificate { get; set; }
        public string AcademicQualificatinDetails { get; set; }
        public int MedicalLicenseNumber { get; set; }
        public string University { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
