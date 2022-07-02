using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sahra.jobManager.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Sahra.jobManager.configurationsCoravel
{
    public class ConfigurationsJobHistoryentity : IEntityTypeConfiguration<Coravel_JobHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<Coravel_JobHistoryEntity> builder)
        {
            builder.ToTable("JobHistories", "Coravel");
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID)
                .ValueGeneratedOnAdd()
                .IsRequired();


            builder.Property(a => a.StartedAt)
                .IsRequired(false);

            builder.Property(a => a.EndedAt)
             .IsRequired(false);

            builder.Property(a => a.TypeFullPath)
              .HasMaxLength(1024)
              .IsRequired(false);

            builder.Property(a => a.DisplayName)
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(a => a.Failed)
                .IsRequired(true);

            builder.Property(a => a.ErrorMessage)
                .HasMaxLength(1024)
                .IsRequired(false);
 
            builder.Property(a => a.StackTrace)
                .HasMaxLength(1024)
                .IsRequired(false);




        }
    }

}
