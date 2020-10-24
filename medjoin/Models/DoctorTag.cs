using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class DoctorTag
    {
        [Key]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
