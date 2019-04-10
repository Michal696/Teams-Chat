using Teams.BL.Factories;
using Teams.DAL;
using Microsoft.EntityFrameworkCore;

namespace Teams.BL.Tests
{
    class InMemoryDbContextFactory : IDbContextFactory
    {
        public TeamsDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeamsDbContext>();
            optionsBuilder.UseInMemoryDatabase("TeamsDB");
            return new TeamsDbContext(optionsBuilder.Options);
        }
    }
}