using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlibrary
{
    class Context : DbContext
    {
        public DbSet<Speler> Spelers{ get; set; }
        public DbSet<Team> Teams{ get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=EF_Opdracht;Integrated Security=True");
        }
    }
}

