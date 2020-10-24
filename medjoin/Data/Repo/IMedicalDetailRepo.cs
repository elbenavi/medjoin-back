using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface IMedicalDetailRepo
    {
        IEnumerable<MedicalDetail> GetMedicalDetails();
        void CreateDoctorMedicalDetail(MedicalDetail MedicalDetail);
    }
}
