using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINM.WEB
{
    public interface IRepository
    {
        IQueryable<Geek> Get();
        void Add(Geek geek);
        IQueryable<Geek> GetExpertGeeks();
        int SaveChanges();
    }
}
