﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teams.DAL;

namespace Teams.DAL.Migrations
{
    [DbContext(typeof(TeamsDbContext))]
    [Migration("20190409220619_DbFixes1")]
    partial class DbFixes1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teams.DAL.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Teams.DAL.Entities.GroupUserPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("MemberId");

                    b.Property<int>("Permit");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("MemberId");

                    b.ToTable("GroupsUserPermissions");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data");

                    b.Property<Guid?>("ParentId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<int>("State");

                    b.Property<string>("Text");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("TaskId");

                    b.Property<Guid?>("TaskStateChangeId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("TaskStateChangeId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskAssignments");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskStateChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<int>("State");

                    b.Property<Guid?>("TaskId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskStateChange");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TeamMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("TeamId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("TeamMember");
                });

            modelBuilder.Entity("Teams.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<byte[]>("Image");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Group", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.GroupUserPermission", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany("GroupUserPermissions")
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.User", "Member")
                        .WithMany("GroupUserPermissions")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Media", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Message", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("Teams.DAL.Entities.User")
                        .WithMany("MediaEntities")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Message", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.Message", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("Teams.DAL.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.Task", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskAssignment", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Task", "Task")
                        .WithMany("TaskAssignments")
                        .HasForeignKey("TaskId");

                    b.HasOne("Teams.DAL.Entities.TaskStateChange")
                        .WithMany("TaskAssignments")
                        .HasForeignKey("TaskStateChangeId");

                    b.HasOne("Teams.DAL.Entities.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TaskStateChange", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Teams.DAL.Entities.Task", "Task")
                        .WithMany("TaskStateChanges")
                        .HasForeignKey("TaskId");

                    b.HasOne("Teams.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.TeamMember", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("Teams.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teams.DAL.Entities.User", b =>
                {
                    b.HasOne("Teams.DAL.Entities.Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
