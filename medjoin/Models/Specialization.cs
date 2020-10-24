using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        public string SpecializationName { get; set; }
    }
}
