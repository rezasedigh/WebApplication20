using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sahra.jobManager.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahra.jobManager.configurationsCoravel
{
    public class ConfigurationsScheduledJobHistoryentity : IEntityTypeConfiguration<Coravel_ScheduledJobHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<Coravel_ScheduledJobHistoryEntity> builder)
        {
            builder.ToTable("ScheduledJobHistories", "Coravel");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.EndedAt)
            .IsRequired(false);



            builder.Property(a => a.TypeFullPath)
              .HasMaxLength(1024)
              .IsRequired(false);

            builder.Property(a => a.DisplayName)
            .HasMaxLength(1024)
            .IsRequired(false);

            builder.Property(a => a.Failed)
          .IsRequired(false);

            builder.Property(a => a.ErrorMessage)
       .HasMaxLength(1024)
       .IsRequired(false);

            builder.Property(a => a.StackTrace)
       .HasMaxLength(1024)
       .IsRequired(false);


        }


    }
}
