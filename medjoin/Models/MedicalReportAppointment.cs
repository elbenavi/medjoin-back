using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class MedicalReportAppointment
    {
        [Key]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int MedicalReportId { get; set; }
        public MedicalReport MedicalReport { get; set; }
    }
}
