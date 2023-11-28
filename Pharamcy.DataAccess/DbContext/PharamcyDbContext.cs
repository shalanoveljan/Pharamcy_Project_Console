using Microsoft.EntityFrameworkCore;
using Pharamcy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.DataAccess.DbContext
{
    public class PharamcyDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-K5FKBJO\\SQLEXPRESS;Database=PharamcyDB2;Trusted_Connection=true;TrustServerCertificate=True;");
        }

       
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Pharamcy.Core.Models.Pharamcy> Pharamcies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleType>().HasMany(x => x.Employes).WithOne(x => x.Role);
            base.OnModelCreating(modelBuilder);
        }
    }
}
