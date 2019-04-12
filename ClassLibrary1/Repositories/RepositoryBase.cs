using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teams.DAL.Entities;
using Teams.BL.Factories;
using Teams.BL.Models;
using Teams.BL.Mapper;
using Teams.BL;
using Teams.DAL;

namespace Teams.BL.Repositories
{
    public class RepositoryBase
    {

        protected readonly IDbContextFactory dbContextFactory;
        protected readonly IMapper mapper;
        protected readonly TeamsDbContext dbContext;

        public RepositoryBase(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
            this.dbContext = dbContextFactory.CreateDbContext();
        }
    }
}