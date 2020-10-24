using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class MedicalDetailRepoImpl : IMedicalDetailRepo
    {
        public Context _context { get; }
        public MedicalDetailRepoImpl(Context context)
        {
            _context = context;
        }
        public void CreateDoctorMedicalDetail(MedicalDetail MedicalDetail)
        {
            _context.MedicalDetails.Add(MedicalDetail);
            _context.SaveChanges();
        }

        public IEnumerable<MedicalDetail> GetMedicalDetails()
        {
            return _context.MedicalDetails.ToList();
        }
    }
}
