namespace RPS.Application.ViewModel
{
    public class GameStatisticViewModel
    {
        public int GameId { get; set; }

        public UserViewModel FirstUser { get; set; }

        public UserViewModel SecondUser { get; set; }

        public int Winner { get; set; }

        public bool IsClosed { get; set; }
    }
}
