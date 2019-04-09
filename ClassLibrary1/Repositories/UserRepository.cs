﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Mapper;
using Teams.BL;

namespace Teams.BL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;

        public UserRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public UserModel Create(UserModel model)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.UserModelToUserEntity(model);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return mapper.UserEntityToUserModel(entity);
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

        public IEnumerable<UserModel> GetAll()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return dbContext.Users
                    .Select(e => mapper.UserEntityToUserModel(e)).ToList();
            }

        }

        public UserModel GetById(Guid Id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == Id);
                return mapper.UserEntityToUserModel(entity);
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