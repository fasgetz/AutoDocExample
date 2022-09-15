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
    /// <summary>
    /// Конфигурация задачи
    /// </summary>
    public class TaskAutoDocEntityTypeConfiguration : IEntityTypeConfiguration<TaskAutoDoc>
    {
        public void Configure(EntityTypeBuilder<TaskAutoDoc> builder)
        {
            builder.ToTable("Task", "AutoDoc");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.CreatedDate)
                .IsRequired();

            builder.HasMany(e => e.Files)
                .WithOne(e => e.Task)
                .HasForeignKey(e => e.TaskId);
        }
    }
}
