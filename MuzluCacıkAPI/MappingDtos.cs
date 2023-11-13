using AutoMapper;
using MuzluCacıkAPI.Dto;
using MuzluCacıkAPI.Models;

namespace MuzluCacıkAPI
{
    public class MappingDtos : Profile
    {
        public MappingDtos() {
            CreateMap<Player, PlayerDto>();
        }
    }
}
