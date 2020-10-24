using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class MedicalReportRepoImpl : IMedicalReportRepo
    {
        public Context _context { get; }

        public MedicalReportRepoImpl(Context context)
        {
            _context = context;
        }

        public void CreateMedicalReports(MedicalReport MedicalReport)
        {
            _context.MedicalReports.Add(MedicalReport);
            _context.SaveChanges();
        }

        public IEnumerable<MedicalReport> GetMedicalReportsByUserId(int id)
        {
            return _context.MedicalReports.Where(m => m.UserId == id);
        }

        public void DeleteMedicalReports(MedicalReport MedicalReport)
        {
            _context.Remove(MedicalReport);
            _context.SaveChanges();
        }

        public MedicalReport GetMedicalReportsById(int id)
        {
            return _context.MedicalReports.FirstOrDefault(m => m.Id == id);
        }
    }
}
