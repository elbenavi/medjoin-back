using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class DoctorSpecialization
    {
        [Key]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specializations { get; set; }
    }
}
