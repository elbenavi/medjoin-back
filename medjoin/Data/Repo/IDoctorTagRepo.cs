using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface IDoctorTagRepo
    {
        IEnumerable<DoctorTag> GetDoctorTags();
        void CreateDoctorTag(DoctorTag DoctorTag);
    }
}
