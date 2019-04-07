using System;
using System.Collections.Generic;
using System.Text;
using Teams.DAL;

namespace CookBook.BL.Factories
{
    public interface IDbContextFactory
    {
        TeamsDbContext CreateDbContext();
    }
}