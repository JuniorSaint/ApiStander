using System;
using Api.Data.Identity;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserIdentity>
    {
        public void Configure(EntityTypeBuilder<UserIdentity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(20);
            builder.Property(u => u.NormalizedUserName).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(60);
            builder.Property(u => u.NormalizedEmail).IsRequired().HasMaxLength(60);
            builder.Property(u => u.UserImage).HasMaxLength(20);
            builder.Property(u => u.UserType).IsRequired().HasMaxLength(20);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(20);
        }
    }
}

