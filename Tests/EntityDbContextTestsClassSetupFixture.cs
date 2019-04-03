using Microsoft.EntityFrameworkCore;
using System;
using Teams.DAL;
using Teams.DAL.Entities;

namespace Tests
{
    public class EntityDbContextTestsClassSetupFixture : IDisposable
    {
        public DbContextFactory dbContextFactory;
        public Context context { get; set; }

        public EntityDbContextTestsClassSetupFixture()
        {
            this.context = CreateEntityDbContext();
        }

        public Context CreateEntityDbContext()
        {
            return dbContextFactory.CreateDbContext();
        }
    

        private DbContextOptions<Context> CreateDbContextOptions()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<Context>();
            contextOptionsBuilder.UseInMemoryDatabase("EntityTeams");
            
            return contextOptionsBuilder.Options;
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}