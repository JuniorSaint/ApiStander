using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class LotConfiguration : IEntityTypeConfiguration<LotEntity>
    {
        public void Configure(EntityTypeBuilder<LotEntity> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.LotName).HasMaxLength(30).IsRequired();
            builder.Property(l => l.Price).HasPrecision(5, 2).IsRequired();
            builder.Property(l => l.Amount).IsRequired();
        }
    }
}

