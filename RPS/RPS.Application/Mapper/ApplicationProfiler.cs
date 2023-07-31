using AutoMapper;
using RPS.Application.ViewModel;
using RPS.Contracts.Models;

namespace RPS.Application.Mapper
{
    public class ApplicationProfiler: Profile
    {
        public ApplicationProfiler()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<Game, GameStatisticViewModel>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.Id))
                .AfterMap((g,vm) =>{
                    var firstUserScore = g.Tournaments.Count(t => t.Winner == 1);
                    var secondUserScore = g.Tournaments.Count(t => t.Winner == 2);

                    if (vm.FirstUser != null)
                        vm.FirstUser.Score = firstUserScore;

                    if (vm.SecondUser != null)
                        vm.SecondUser.Score = secondUserScore;

                    if (g.IsClosed && firstUserScore != secondUserScore)
                        vm.Winner = firstUserScore > secondUserScore ? 1 : 2;
                });

        }
    }
}
