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
            return new Context(optionsBuilder.Options);

        }

    }
}
