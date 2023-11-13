using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MuzluCacıkAPI.Data;
using MuzluCacıkAPI.Models;
using MuzluCacıkAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzluCacıkAPI.Test.Repository
{
    public class PlayerRepositoryTest
    {
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Players.CountAsync() <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    databaseContext.Players.Add(
                        new Player()
                        {
                            Name = "Tsubasa",
                            BirthDate = DateTime.Now
                        });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void PlayerRepository_GetPlayerByName_ReturnsPlayer()
        {
            //Arrange
            var name = "Tsubasa";
            var dbContext = await GetDatabaseContext();
            var playerRepository = new PlayerRepository(dbContext);

            //Act
            var result = playerRepository.GetPlayerByName(name);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Player>();
        }

        [Fact]
        public async void PlayerRepository_UpdatePlayer_ReturnsTrue()
        {
            //Arrange
            Player player = new Player()
            {
                Name = "Wakabayashi",
                BirthDate = new DateTime(1999, 05, 05)
            };
            var dbContext = await GetDatabaseContext();
            var playerRepository = new PlayerRepository(dbContext);

            //Act
            var result = playerRepository.UpdatePlayer(player);

            //Assert
            result.Should().BeTrue();
        }
    }
}
