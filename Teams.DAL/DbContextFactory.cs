using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.DAL
{
    public class DbContextFactory
    {
        public Context CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
              Initial Catalog = Teams;
             MultipleActiveResultSets = True;
               Integrated Security = True; ");
            return new Context(optionsBuilder.Options);

        }

    }
}
