﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("Homeworks").HasKey(h => h.Id);

            builder.Property(h => h.Id).HasColumnName("Id").IsRequired();
            builder.Property(h => h.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(h => h.EndOfDate).HasColumnName("EndOfDate").IsRequired();
            builder.Property(h => h.InstructorDescription).HasColumnName("InstructorDescription");
            builder.Property(h => h.StudentDescription).HasColumnName("StudentDescription");

            builder.HasOne(h => h.Course).WithMany(c => c.Homeworks).HasForeignKey(h => h.CourseId);

            builder.HasMany(h => h.Files).WithOne(f => f.Homework).HasForeignKey(f => f.HomeworkId);

            builder.HasQueryFilter(h => !h.DeletedDate.HasValue);
        }
    }

}