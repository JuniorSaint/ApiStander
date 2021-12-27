﻿using System;
using Api.Domain.Entities;
using Api.Domain.Utilities;

namespace Api.Domain.Interfaces
{
    public interface ISpeakerRepository : IRepository<SpeakerEntity>
    {
        Task<PageList<SpeakerEntity>> GetEventByTermAsync(PageParams pageParams);
        Task<SpeakerEntity> SelectByICompletedAsync(Guid id);
    }
}

