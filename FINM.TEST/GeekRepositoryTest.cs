using FINM.WEB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FINM.TEST
{
    public class GeekRepositoryTest : IClassFixture<DatabaseFixture>
    {
        Repository repository;
        public GeekRepositoryTest(DatabaseFixture fixture)
        {
            repository = new Repository(fixture.ApplicationDbContext);
        }

        [Fact]
        public void GetExpertGeeks()
        {
            var expertGeeks = repository.GetExpertGeeks();
            Assert.Equal(2, expertGeeks.Count());
        }

        [Fact]
        public void Get()
        {
            var allGeeks = repository.Get();
            Assert.Equal(3, allGeeks.Count());
        }
    }

    public class DatabaseFixture
    {
        public DatabaseFixture()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase();
            var options = builder.Options;

            ApplicationDbContext = new ApplicationDbContext(options);

            var geeks = new List<Geek>
                {
                    new Geek { Id= 1, Name = "Mr. Anderson", Expertise = "Machine Learning", Rating = 4},
                    new Geek { Id= 2, Name = "Fiyaz Hasan", Expertise = "ASP.NET Core", Rating = 3.52M },
                    new Geek { Id= 3, Name = "Jon Doe", Expertise = "Python", Rating = 3 },
                    new Geek { Id= 4, Name = "Jane DOe", Expertise = "Data Science", Rating = 2.52M }
                };

            ApplicationDbContext.AddRange(geeks);
            ApplicationDbContext.SaveChanges();
        }
        public ApplicationDbContext ApplicationDbContext { get; private set; }
    }
}
