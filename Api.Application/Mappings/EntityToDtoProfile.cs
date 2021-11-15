using Api.Application.Dtos.Event;
using Api.Application.Dtos.Lot;
using Api.Application.Dtos.SocialMedia;
using Api.Application.Dtos.Speaker;
using Api.Application.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;


namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User Dto
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserCreateDto, UserEntity>().ReverseMap();
            CreateMap<UserUpdateDto, UserEntity>().ReverseMap();
            CreateMap<UserUpdateResultDto, UserEntity>().ReverseMap();
            #endregion

            #region Event Dto
            CreateMap<EventDto, EventEntity>().ReverseMap();
            CreateMap<EventCreateDto, EventEntity>().ReverseMap();
            CreateMap<EventUpdateDto, EventEntity>().ReverseMap();
            #endregion

            #region Lot Dto
            CreateMap<LotDto, LotEntity>().ReverseMap();
            CreateMap<LotCreateDto, LotEntity>().ReverseMap();
            CreateMap<LotUpdateDto, LotEntity>().ReverseMap();
            #endregion

            #region SocialMedia Dto
            CreateMap<SocialMediaDto, SocialMediaEntity>().ReverseMap();
            CreateMap<SocialMediaCreateDto, SocialMediaEntity>().ReverseMap();
            CreateMap<SocialMediaUpdateDto, SocialMediaEntity>().ReverseMap();
            #endregion

            #region Speaker Dto
            CreateMap<SpeakerDto, SpeakerEntity>().ReverseMap();
            CreateMap<SpeakerCreateDto, SpeakerEntity>().ReverseMap();
            CreateMap<SpeakerUpdateDto, SpeakerEntity>().ReverseMap();
            #endregion
        }
    }
}

