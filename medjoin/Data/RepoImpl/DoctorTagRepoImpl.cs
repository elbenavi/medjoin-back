using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class DoctorTagRepoImpl: IDoctorTagRepo
    {
        public Context _context { get; }

        public DoctorTagRepoImpl(Context context)
        {
            _context = context;
        }

        public IEnumerable<DoctorTag> GetDoctorTags()
        {
            return _context.DoctorTags.ToList();
        }

        public void CreateDoctorTag(DoctorTag DoctorTag)
        {
            _context.DoctorTags.Add(DoctorTag);
            _context.SaveChanges();
        }
    }
}
