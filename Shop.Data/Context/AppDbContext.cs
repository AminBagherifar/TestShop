using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;
using Shop.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Apply Entities Mapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
