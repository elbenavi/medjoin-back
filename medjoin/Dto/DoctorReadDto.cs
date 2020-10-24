using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Dto
{
    public class DoctorReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlImg { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
        public IEnumerable<Specialization> Specializations { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Schedule> Schedule { get; set; }
    }
}
