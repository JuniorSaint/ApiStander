using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Domain.Entities;

namespace Api.Data.EntityConfiguration
{
    public class EventConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Local).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Theme).HasMaxLength(100).IsRequired();
            builder.Property(e => e.EventImage).HasMaxLength(40);
            builder.Property(e => e.Local).HasMaxLength(40);
            builder.Property(e => e.Local).HasMaxLength(50);
            builder.HasMany(e => e.Lots).WithOne(e => e.Event).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.SocialMedias).WithOne(e => e.Event).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
