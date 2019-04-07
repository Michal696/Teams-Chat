using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL;

namespace Teams.BL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbContextFactory dbContextFactory;
        Mapper Mapper = new Mapper();

        public UserRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public UserRepository()
        {

        }

        public UserModel Create(UserModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.UserModelToUserEntity(model);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return Mapper.UserEntityToUserModel(entity);
            }
        }

        public void Delete(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == id);
                dbContext.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public List<UserModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Users
                    .Select(e => Mapper.UserEntityToUserModel(e)).ToList();
            }

        }

        public UserModel GetById(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == Id);
                return Mapper.UserEntityToUserModel(entity);
            }
        }

        public void Update(UserModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = Mapper.UserModelToUserEntity(model);
                dbContext.Users.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}