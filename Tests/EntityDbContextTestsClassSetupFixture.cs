using Microsoft.EntityFrameworkCore;
using System;
using Teams.DAL;
    

namespace Tests
{
    public class EntityDbContextTestsClassSetupFixture : IDisposable
    {
        public TeamsDbContext EntityDbContextSUT { get; set; }

        public EntityDbContextTestsClassSetupFixture()
        {
            this.EntityDbContextSUT = CreateEntityDbContext();
        }

        public TeamsDbContext CreateEntityDbContext()
        {
            return new TeamsDbContext(CreateDbContextOptions());
        }


        private DbContextOptions<TeamsDbContext> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<TeamsDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase("EntityTeams");

            return contextOptionsBuilder.Options;
        }

        public void Dispose()
        {
            EntityDbContextSUT?.Dispose();
        }
    }
}