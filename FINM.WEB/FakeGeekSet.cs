using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FINM.WEB
{
    public class FakeGeekSet : DbSet<Geek>
    {
        public FakeGeekSet()
        {
        }

        //public override EntityEntry<Geek> Add([NotNullAttribute] Geek entity)
        //{
        //    return base.Add(entity);
        //}
    }
}
