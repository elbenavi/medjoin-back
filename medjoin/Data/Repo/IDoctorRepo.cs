using medjoin.Dto;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface IDoctorRepo
    {
        IEnumerable<DoctorReadDto> GetDoctors();
        void CreateDoctor(Doctor doctor);
    }
}
