using AutoDoc.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Domain.EntityConfigurations
{
    public class TaskAutoDocStatusEntityTypeConfiguration : IEntityTypeConfiguration<AutoDocStatus>
    {
        public void Configure(EntityTypeBuilder<AutoDocStatus> builder)
        {
            builder.ToTable("Statuses", "AutoDoc");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(e => e.Tasks)
                .WithOne(e => e.TaskStatus)
                .HasForeignKey(e => e.TaskStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Files)
                .WithOne(e => e.FileStatus)
                .HasForeignKey(e => e.FileStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
