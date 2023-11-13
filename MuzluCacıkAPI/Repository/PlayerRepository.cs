using MuzluCacıkAPI.Data;
using MuzluCacıkAPI.Models;

namespace MuzluCacıkAPI.Repository
{
    public class PlayerRepository : IPlayerRepository

    {
        private readonly DataContext _context;
        public PlayerRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreatePlayer(string name, DateTime birthDate)
        {
            var newPlayer = new Player()
            {
                Name = name,
                BirthDate = birthDate
            };
            _context.Add(newPlayer);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeletePlayer(int playerId)
        {
            var player = _context.Players.Where(x => x.Id == playerId);
            if (player != null)
            {
                _context.Remove(player);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            //Or we may use try-catch but since I just need if for tests, i just put it here like this.
        }

        public ICollection<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            try
            {
                Player requestedPlayer = _context.Players.FirstOrDefault(x => x.Id == id);
                return requestedPlayer;
            }
            catch (Exception ex)
            {
                //There should be some logger or something to hold this... but instead i just returned empty Player
                return new Player();
            }
        }

        public Player GetPlayerByName(string name)
        {
            Player player = _context.Players.FirstOrDefault(y => y.Name == name);
            if (player != null)
            {
                return player;
            }
            else
            {
                return new Player();
            }
        }

        public bool PlayersExist(int playerId)
        {
            return _context.Players.Any(x => x.Id == playerId);
        }

        public bool UpdatePlayer(Player player)
        {
            _context.Update(player);
            _context.SaveChanges();
            return true;
            //So cheap, this should be more detailed but that is not the point here.
        }
    }
}
