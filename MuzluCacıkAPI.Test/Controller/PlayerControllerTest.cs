using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MuzluCacıkAPI.Controllers;
using MuzluCacıkAPI.Dto;
using MuzluCacıkAPI.Models;
using MuzluCacıkAPI.Repository;

namespace MuzluCacıkAPI.Test.Controller
{
    public class PlayerControllerTest
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerControllerTest()
        {
            //Bring dependencies in ctor first. MOCKING
            _playerRepository = A.Fake<IPlayerRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PlayerController_GetPlayers_ReturnOK()
        {
            //Arrange
            var players = A.Fake<ICollection<PlayerDto>>();
            var playersList = A.Fake<List<PlayerDto>>();
            A.CallTo(() => _mapper.Map<List<PlayerDto>>(players)).Returns(playersList);

            var FakeController = new PlayerController(_playerRepository, _mapper);

            //Act
            var result = FakeController.GetPlayers();

            //Assert
            result.Should().NotBeNull(); //Something should be there, which means list should be something rather then null
            result.Should().BeOfType(typeof(OkObjectResult)); //Controller should return OK in the end if they work corretly
        }

        [Fact]
        public void PlayerController_CreatePlayer_ReturnsOK()
        {
            //Arrange
            var player = A.Fake<Player>();
            var playerCreate = A.Fake<PlayerDto>();
            /* Static Method cannot be tested, or basically cannot be arranged.
            A.CallTo(() => _playerRepository.GetAllPlayers().Where(p => p.Name.Trim().ToUpper() == player.Name.ToUpper())
                .FirstOrDefault()).Returns(player); */
            A.CallTo(() => _mapper.Map<Player>(playerCreate)).Returns(player);

            var controller = new PlayerController(_playerRepository, _mapper);

            //Act
            var result = controller.CreatePlayer(playerCreate);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
