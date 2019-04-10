using System;
using System.Collections.Generic;
using System.Text;
using Teams.DAL;

namespace Teams.BL.Factories
{
    public interface IDbContextFactory
    {
        TeamsDbContext CreateDbContext();
    }
}