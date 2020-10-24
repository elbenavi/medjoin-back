using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
        public IEnumerable<DoctorSpecialization> DoctorSpecializations { get; set; }
        public IEnumerable<DoctorTag> DoctorTags { get; set; }
        public IEnumerable<DoctorShedule> DoctorShedules { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
