using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.EntityConfiguration
{
    public class SpeakerEventConfiguration : IEntityTypeConfiguration<SpeakerEventEntity>
    {
        public void Configure(EntityTypeBuilder<SpeakerEventEntity> builder)
        {
            builder.HasKey(ur => new { ur.EventId, ur.SpeakerId });
        }
    }
}

