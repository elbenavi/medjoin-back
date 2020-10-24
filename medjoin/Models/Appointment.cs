using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime PreferredDate { get; set; }
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime endAppoinment { get; set; }
        [Required(ErrorMessage = "Reason is Required")]
        public string Reason { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public User User { get; set; }
        public User Doctor { get; set; }
        public IEnumerable<MedicalReportAppointment> MedicalReportAppointments { get; set; }
    }
}
