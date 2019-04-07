using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TeamsDbContext>
    {
        public TeamsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeamsDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new TeamsDbContext(optionsBuilder.Options);

        }

    }
}
