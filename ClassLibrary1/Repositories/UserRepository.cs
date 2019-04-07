using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Factories;

namespace Teams.BL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        public UserRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
    }
}
