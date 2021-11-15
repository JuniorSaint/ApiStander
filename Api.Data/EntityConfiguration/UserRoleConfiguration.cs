using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            //builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            //builder.HasOne(ur => ur.UserEntity).WithMany(ur => ur.UserRoles).HasForeignKey(ur => ur.UserId);
            //builder.HasOne(ur => ur.RoleEntity).WithMany(ur => ur.UserRoles).HasForeignKey(ur => ur.RoleId);
        }
    }
}

