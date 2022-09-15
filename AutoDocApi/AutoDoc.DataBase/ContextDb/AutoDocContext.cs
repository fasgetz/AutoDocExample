using AutoDoc.Domain.EntityConfigurations;
using AutoDoc.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.DataBase.ContextDb
{
    public class AutoDocContext : DbContext
    {
        public AutoDocContext(DbContextOptions<AutoDocContext> options)
            : base(options)
        {

        }

        #region DbSets - список дб сетов
        public DbSet<TaskAutoDoc> Tasks { get; set; }
        public DbSet<FileAutoDoc> Files { get; set; }
        public DbSet<AutoDocStatus> Statuses { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("AutoDoc");

            #region EntityTypeConfigurations
            modelBuilder.ApplyConfiguration(new FileAutoDocEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskAutoDocStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskAutoDocEntityTypeConfiguration());
            #endregion
        }
    }
}
