﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using PMTool.Models;

namespace PMTool.Repository
{
    public class PMToolContext : DbContext
    {

        //public DbSet<PMTool.Models.Test> Tests { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<PMTool.Models.Priority> Priorities { get; set; }

        public DbSet<PMTool.Models.Label> Labels { get; set; }

        public DbSet<PMTool.Models.Project> Projects { get; set; }

        public DbSet<PMTool.Models.Task> Tasks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().
                HasMany(i => i.Users).
                WithMany(c => c.Projects).
                Map(mc =>
                {
                    mc.MapLeftKey("ProjectId");
                    mc.MapRightKey("UserId");
                    mc.ToTable("ProjectUsers");
                });

            modelBuilder.Entity<Task>().
                HasMany(i => i.Users).
                WithMany(c => c.Tasks).
                Map(mc =>
                {
                    mc.MapLeftKey("TaskId");
                    mc.MapRightKey("UserId");
                    mc.ToTable("TaskUsers");
                });

            modelBuilder.Entity<Task>().
               HasMany(i => i.Followers).
               WithMany(c => c.FollowerTasks).
               Map(mc =>
               {
                   mc.MapRightKey("TaskId");
                   mc.MapLeftKey("UserId");
                   mc.ToTable("TaskFollowers");
               });

            modelBuilder.Entity<Task>().
              HasMany(i => i.Labels).
              WithMany(c => c.Tasks).
              Map(mc =>
              {
                  mc.MapRightKey("TaskId");
                  mc.MapLeftKey("LabelId");
                  mc.ToTable("TaskLabels");
              });
        }

    }
}