using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Email is Required")]
        [Remote("IsExist", "Place", ErrorMessage = "URL exist!")]
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        // [Required(ErrorMessage = "Password is Required")]
        // [DataType(DataType.Password, ErrorMessage ="Error password")]
        public string Password { get; set; }
        public string ImgProfile { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(30)]
        public string LastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Ext is Required")]
        public string Ext { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Aboutyou { get; set; }
        public String Address { get; set; }
        public bool IsDoctor { get; set; }
        public string Rol { get; set; }

        public override string ToString()
        {
            return Email + " -- " + Password + " -- " + FirstName + " -- " + LastName;
        }
    }
}
