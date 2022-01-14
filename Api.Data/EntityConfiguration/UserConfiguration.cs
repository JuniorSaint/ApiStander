using Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.UserEmail).IsUnique();
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
                    Password = NewMethod(),
                    UserType = "Admin",
                });
        }

        private static string NewMethod()
        {
            //var passwordHasher = new PasswordHasher<UserEntity>();
            //return passwordHasher.HashPassword(UserEntity as user, "123456");
            return null;
        }
    }
}
