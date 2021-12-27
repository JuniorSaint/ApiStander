using System;
using Api.Application.Dtos.ListSocialMedia;

namespace Api.Application.Interfaces
{
    public interface IListSocialMediaService
    {
        Task<IEnumerable<ListSocialMediaDto>> GetListSocialMedias();
    }
}

