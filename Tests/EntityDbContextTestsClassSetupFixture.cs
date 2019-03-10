using Microsoft.EntityFrameworkCore;
using System;
using Teams.Models;

namespace Tests
{
    public class EntityDbContextTestsClassSetupFixture : IDisposable
    {
        public Context EntityDbContextSUT { get; set; }

        public EntityDbContextTestsClassSetupFixture()
        {
            this.EntityDbContextSUT = CreateEntityDbContext();
        }

        public Context CreateEntityDbContext()
        {
            return new Context(CreateDbContextOptions());
        }
    

        private DbContextOptions<Context> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<Context>();
            contextOptionsBuilder.UseInMemoryDatabase("EntityTeams");
            
            return contextOptionsBuilder.Options;
        }

        public void Dispose()
        {
            EntityDbContextSUT?.Dispose();
        }
    }
}