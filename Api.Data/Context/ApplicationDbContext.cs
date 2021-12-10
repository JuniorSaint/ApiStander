using System;
using Api.Data.Identity;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{

    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<EventEntity> Events { get; set; }
        public DbSet<LotEntity> Lots { get; set; }
        public DbSet<SocialMediaEntity> SocialMedias { get; set; }
        public DbSet<SpeakerEntity> Speakers { get; set; }
        public DbSet<SpeakerEventEntity> SpeakerEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
