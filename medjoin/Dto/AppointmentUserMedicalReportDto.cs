using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Dto
{
    public class AppointmentUserMedicalReportDto
    {
        public int Id { get; set; }
        public DateTime PreferredDate { get; set; }
        public DateTime endAppoinment { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
        public User Doctor { get; set; }
        public IEnumerable<MedicalReport> MedicalReports { get; set; }
    }
}
