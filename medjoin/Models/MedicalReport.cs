using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class MedicalReport
    {
        [Key]
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string UrlResource { get; set; }
        public int SizeFile { get; set; }
        public DateTime UploadDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
