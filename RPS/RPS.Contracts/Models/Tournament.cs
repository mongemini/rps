namespace RPS.Contracts.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public RPSType FirstUserResult { get; set; }

        public RPSType SecondUserResult { get; set; }

        public int Winner { get; set; }
    }
}
