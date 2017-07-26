using FINM.WEB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FINM.TEST
{
    public class GeekRepositoryTest
    {
        [Fact]
        public void GetExpertGeeks()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase();
            var options = builder.Options;

            using (var context = new ApplicationDbContext(options))
            {
                var geeks = new List<Geek>
                {
                    new Geek { Id= 1, Name = "Tanzim Saqib", Expertise = "Machine Learning", Rating = 4},
                    new Geek { Id= 2, Name = "Fiyaz Hasan", Expertise = "ASP.NET Core", Rating = 3.52M },
                    new Geek { Id= 3, Name = "Jon Doe", Expertise = "Python", Rating = 3 },
                    new Geek { Id= 4, Name = "Jane DOe", Expertise = "Data Science", Rating = 2.52M }
                };

                context.AddRange(geeks);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new Repository(context);
                var expertGeeks = repository.GetExpertGeeks();
                Assert.Equal(2, expertGeeks.Count());
            }
        }
    }
}
