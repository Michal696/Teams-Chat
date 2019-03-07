using System;
using Microsoft.EntityFrameworkCore;
using Teams.Models.Entities;

namespace Teams.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> contextOptions)
               : base(contextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
            
          optionsBuilder.UseSqlServer(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              Initial Catalog = Teams;
             MultipleActiveResultSets = True;
               Integrated Security = True; ");
       }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GroupUserPermission> GroupsUserPermissions { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Task>  Tasks { get; set; }

    }
}
