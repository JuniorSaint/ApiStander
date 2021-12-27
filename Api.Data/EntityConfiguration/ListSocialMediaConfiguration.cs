using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class ListSocialMediaConfiguration : IEntityTypeConfiguration<ListSocialMediaEntity>
    {
        public void Configure(EntityTypeBuilder<ListSocialMediaEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.SocialMediaName).HasMaxLength(100).IsRequired();

            builder.HasData
            (
               new { Id = Guid.NewGuid(), SocialMediaName = "Facebook" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Instagram" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Gettr" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Telegram" },
               new { Id = Guid.NewGuid(), SocialMediaName = "WeChat" },
               new { Id = Guid.NewGuid(), SocialMediaName = "QZone" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Tumblr" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Twitter" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Google+" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Skype" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Viber" },
               new { Id = Guid.NewGuid(), SocialMediaName = "line" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Sina Weibo" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Snapchat" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Pinterest" },
               new { Id = Guid.NewGuid(), SocialMediaName = "LinkedIn" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Reddit" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Taringa" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Foursquare" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Badoo" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Myspace" },
               new { Id = Guid.NewGuid(), SocialMediaName = "YouTube" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Upstream" },
               new { Id = Guid.NewGuid(), SocialMediaName = "MeetMe" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Vero" },
               new { Id = Guid.NewGuid(), SocialMediaName = "TikTok" },
               new { Id = Guid.NewGuid(), SocialMediaName = "WT Social" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Caffeine" },
               new { Id = Guid.NewGuid(), SocialMediaName = "italki" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Vimeo" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Gab" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Rumble" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Parler" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Odysee" },
               new { Id = Guid.NewGuid(), SocialMediaName = "Github" }
            );
        }

    }
}
