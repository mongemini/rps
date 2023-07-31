
namespace RPS.Contracts.Models
{
    public class Game
    {
        public int Id { get; set; }

        public User? FirstUser { get; set; }

        public User? SecondUser { get; set; }

        public IList<Tournament> Tournaments { get; set; } = new List<Tournament>();

        public bool IsClosed { get; set; }
    }
}
