using MuzluCacıkAPI.Data;
using MuzluCacıkAPI.Models;

namespace MuzluCacıkAPI
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext context)
        {
            this._dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.Players.Any())
            {
                var players = new List<Player>() 
                {
                    new Player()
                    {
                        Name = "Tsubasa",
                        BirthDate = new DateTime(1981,7,28)
                    },
                    new Player()
                    {
                        Name = "Wakabayashi",
                        BirthDate = new DateTime(1981,12,27)
                    }
                };
                _dataContext.Players.AddRange(players);
                _dataContext.SaveChanges();
            }
        }
    }
}
