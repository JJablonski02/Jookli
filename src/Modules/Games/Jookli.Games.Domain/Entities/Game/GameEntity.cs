namespace Jookli.Games.Domain.Entities.Game
{
    public class GameEntity
    {
        public Guid GameId { get; set; }
        public string FullName { get; set; }
        public int Counter { get; set; }
        public string GameOwner { get; set; }
    }
}
