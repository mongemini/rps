using RPS.Contracts.Models;

namespace RPS.Application.ViewModel
{
    public  class UserStepViewModel
    {
        public int GameId { get; set; }

        public int UserId { get; set; }

        public RPSType Turn { get; set; }
    }
}
