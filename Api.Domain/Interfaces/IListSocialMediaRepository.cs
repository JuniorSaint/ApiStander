using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IListSocialMediaRepository
    {
         Task<IEnumerable<ListSocialMediaEntity>> GetAllListSocialMedia();
    }
}

