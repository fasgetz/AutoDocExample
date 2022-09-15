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
    /// Конфигурация файлов
    /// </summary>
    public class FileAutoDocEntityTypeConfiguration : IEntityTypeConfiguration<FileAutoDoc>
    {
        public void Configure(EntityTypeBuilder<FileAutoDoc> builder)
        {
            builder.ToTable("File", "AutoDoc");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
