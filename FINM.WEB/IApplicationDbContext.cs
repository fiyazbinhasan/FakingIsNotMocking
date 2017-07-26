using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINM.WEB
{
    public interface IApplicationDbContext
    {
        DbSet<Geek> Geeks { get; }
    }
}
