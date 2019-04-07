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

        public UserRepository()
        {

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

        public UserModel GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}