using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teams.BL.Factories;
using Teams.BL.Models;

namespace Teams.BL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbContextFactory dbContextFactory;

        public UserRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }


        public UserModel Create(UserModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}