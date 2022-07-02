using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sahra.jobManager.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahra.jobManager.configurationsCoravel
{
    public class ConfigurationsScheduledJobsentity: IEntityTypeConfiguration<Coravel_ScheduledJobsEntity>
    {
        public void Configure(EntityTypeBuilder<Coravel_ScheduledJobsEntity> builder)
        {
            builder.ToTable("ScheduledJobs", "coravel");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
             .ValueGeneratedOnAdd()
             .IsRequired();

            builder.Property(a => a.Name)
             .HasMaxLength(1024)
             .IsRequired(false);

            builder.Property(a => a.FullName)
             .HasMaxLength(1024)
             .IsRequired(false);


            builder.Property(a => a.CronExpression)
             .HasMaxLength(1024)
             .IsRequired(false);

            builder.Property(a => a.EverySecond)
             .IsRequired(true);

            builder.Property(a => a.EveryMinute)
             .IsRequired(false);

            builder.Property(a => a.EveryHour)
             .IsRequired(false);

            builder.Property(a => a.EveryDayofTheWeeks)
             .HasMaxLength(1024)
             .IsRequired(false);


            builder.Property(a => a.PreventOverlapping)
             .IsRequired(true);

            builder.Property(a => a.CreatedAt)
             .IsRequired(true);

            builder.Property(a => a.Active)
             .IsRequired(true);

            builder.Property(a => a.TimeZoneInfo)
             .HasMaxLength(1024)
             .IsRequired(false);

        }
    }
}
