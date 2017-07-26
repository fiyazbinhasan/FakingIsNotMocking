using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINM.WEB
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Geek geek)
        {
            _context.Geeks.Add(geek);
        }

        public IQueryable<Geek> Get()
        {
            return _context.Geeks;
        }

        public IQueryable<Geek> GetExpertGeeks()
        {
            return _context.Geeks.Where(g => g.Rating >= 3.5M);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
