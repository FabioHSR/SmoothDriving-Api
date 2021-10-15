﻿using Microsoft.EntityFrameworkCore;
using SmoothDriving.Infra.Data.Configurations;
using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDriving.Infra.Data.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<User> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

    }
}
