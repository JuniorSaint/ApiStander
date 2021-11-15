using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMediaEntity>
    {
        public void Configure(EntityTypeBuilder<SocialMediaEntity> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.URL).HasMaxLength(100).IsRequired();
        }
    }
}

