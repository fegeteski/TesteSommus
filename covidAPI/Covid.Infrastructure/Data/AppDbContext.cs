﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Country> Country { get; set; }
    }
}
