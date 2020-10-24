using medjoin.Data.Repo;
using medjoin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medjoin.Data.RepoImpl
{
    public class TagRepoImpl : ITagRepo
    {
        public Context _context { get; }

        public TagRepoImpl(Context context)
        {
            _context = context;
        }
        public void CreateTags(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags.ToList();
        }
    }
}
