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

        public int CalcAge(SpeakerEntity speaker)
        {
            try
            {
                var now = DateTime.UtcNow;
                var monthBirth = speaker.Birthday.Month;
                var monthNow = now.Month;
                var dayBirth = speaker.Birthday.Day;
                var nowDay = now.Day;
                speaker.Age = 0;

                if (speaker.Birthday.ToString() is null || speaker.Birthday <= now)
                    return speaker.Age;

                speaker.Age = (now.Year - speaker.Birthday.Year);

                if (monthBirth < monthNow || (monthBirth == monthNow && dayBirth < nowDay))
                {
                    speaker.Age = speaker.Age - 1;
                }
                return speaker.Age;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

