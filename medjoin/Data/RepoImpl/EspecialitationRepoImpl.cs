using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class EspecialitationRepoImpl : IEspecialitationRepo
    {
        public Context _context { get; }

        public EspecialitationRepoImpl(Context context)
        {
            _context = context;
        }

        public void CreateEspecialitation(Specialization especialitation)
        {
            _context.Especialitations.Add(especialitation);
            _context.SaveChanges();
        }

        public IEnumerable<Specialization> GetEspecialitations()
        {
            return _context.Especialitations.ToList();
        }
    }
}
