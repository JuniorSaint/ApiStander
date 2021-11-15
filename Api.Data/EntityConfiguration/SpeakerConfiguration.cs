using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class SpeakerConfiguration : IEntityTypeConfiguration<SpeakerEntity>
    {
        public void Configure(EntityTypeBuilder<SpeakerEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.SpeakerName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.MiniResume).HasMaxLength(300).IsRequired();
            builder.Property(p => p.SpeakerImage).HasMaxLength(30);
            builder.Property(p => p.SpeakerPhone).HasMaxLength(20);
            builder.HasMany(p => p.SocialMedias).WithOne(p => p.Speaker).OnDelete(DeleteBehavior.Cascade);
        }
    }
}


