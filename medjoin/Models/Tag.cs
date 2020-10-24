using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        // public IEnumerable<DoctorTag> DoctorTags { get; set; }
    }
}
