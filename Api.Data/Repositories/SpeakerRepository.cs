using System;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class SpeakerRepository : BaseRepository<SpeakerEntity>, ISpeakerRepository

    {
        private DbSet<SpeakerEntity> _dataset;

        public SpeakerRepository(ApplicationDbContext contex) : base(contex)
        {
            _dataset = contex.Set<SpeakerEntity>();
        }
    }
}

