using System;
using Microsoft.EntityFrameworkCore;
using Teams;
using Teams.DAL.Entities;

namespace Teams.DAL
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GroupUserPermission> GroupsUserPermissions { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Task>  Tasks { get; set; }
        public DbSet<TaskStateChange> TaskStateChange { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }

    }
}
