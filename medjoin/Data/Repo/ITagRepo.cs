using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.Repo
{
    public interface ITagRepo
    {
        IEnumerable<Tag> GetTags();
        void CreateTags(Tag tag);
    }
}
