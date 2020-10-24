using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Dto
{
    public class UserDoctorReadDto
    {
        public int Id { get; set; }
        public string ImgProfile { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Ext { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Aboutyou { get; set; }
        public string Address { get; set; }
        public bool IsDoctor { get; set; }
        public string Rol { get; set; }
        public MedicalDetail MedicalDetail { get; set; }
    }
}
