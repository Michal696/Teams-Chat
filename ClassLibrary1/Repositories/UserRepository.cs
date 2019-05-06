using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teams.DAL.Entities;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Mapper;
using Teams.BL;
using Teams.BL.Services;

namespace Teams.BL.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IDbContextFactory dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {
        }

        public UserModel Create(UserModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.UserModelToUserEntity(model);
                if (entity.Password != null) entity.Password = SecurePasswordHasher.Hash(entity.Password);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return mapper.UserEntityToUserModel(entity);
            }
        }

        public void Delete(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var user = new User
                {
                    Id = Id
                };
                dbContext.Users.Attach(user);
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            return dbContext.Users
                .Select(mapper.UserEntityToUserModel);
        }

        public UserModel GetById(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.FirstOrDefault(t => t.Id == Id);
                return entity == null ? null : mapper.UserEntityToUserModel(entity);
            }
        }

        public UserModel GetByEmail(String Email)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.FirstOrDefault(t => t.Email == Email);
                return entity == null ? null : mapper.UserEntityToUserModel(entity);
            }
        }

        public void Update(UserModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.UserModelToUserEntity(model);
                dbContext.Users.Update(entity);
                dbContext.SaveChanges();
            }
        }
    }
}