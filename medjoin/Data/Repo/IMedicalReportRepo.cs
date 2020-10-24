using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public interface IMedicalReportRepo
    {
        IEnumerable<MedicalReport> GetMedicalReportsByUserId(int id);

        MedicalReport GetMedicalReportsById(int id);
        void CreateMedicalReports(MedicalReport MedicalReport);

        void DeleteMedicalReports(MedicalReport MedicalReport);
    }
}
