using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teams.DAL;
namespace Teams.BL.Factories
{
    class DbContextFactory
    {
        public Context CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = Teams;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new Context(optionsBuilder.Options);
        }
    }
}
