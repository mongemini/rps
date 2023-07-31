using AutoMapper;
using RPS.API.Models;
using RPS.Contracts.Models;

namespace RPS.API.Mapper
{
    public class ApiProfiler: Profile
    {
        public ApiProfiler()
        {
            CreateMap<Game, CreateGameResult>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstUserId, opt => opt.MapFrom(src => src.FirstUser.Id));

            CreateMap<Game, JoinToGameResult>()
               .ForMember(dest => dest.SecondUserId, opt => opt.MapFrom(src => src.SecondUser.Id));

        }
    }
}
