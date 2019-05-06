using System;
using Microsoft.EntityFrameworkCore;
using Teams;
using Teams.DAL.Entities;

namespace Teams.DAL
{
    public class TeamsDbContext : DbContext
    {
        public TeamsDbContext()
        {
        }

        public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GroupUserPermission> GroupsUserPermissions { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Task>  Tasks { get; set; }
        public DbSet<TaskStateChange> TaskStateChanges { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // inside code needs to be commented for entity tests to work
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
            //  Initial Catalog = Teams;
            // MultipleActiveResultSets = True;
            //   Integrated Security = True; ");
        }

    }
}
