using MuzluCacıkAPI.Models;

namespace MuzluCacıkAPI.Repository
{
    public interface IPlayerRepository
    {
        ICollection<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        Player GetPlayerByName(string name);
        bool PlayersExist(int playerId);
        bool CreatePlayer(string name, DateTime birthDate);
        bool UpdatePlayer(Player player);
        bool DeletePlayer(int playerId);
    }
}
