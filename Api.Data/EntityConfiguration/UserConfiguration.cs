using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(20);
            builder.Property(u => u.UserEmail).IsRequired().HasMaxLength(60);
            builder.Property(u => u.UserImage).HasMaxLength(20);
            builder.Property(u => u.UserType).IsRequired().HasMaxLength(20);

            builder.HasData
                (new
                {
                    Id = Guid.NewGuid(),
                    UserName = "Junior",
                    UserEmail = "junior.garbage@gmail.com",
                    UserImage = "rosto.jpg",
                    IsActive = true,
                    Title = "Tecnologo",
                    Password = "123456",
                    UserType = "Admin"
                });
        }
    }
}
