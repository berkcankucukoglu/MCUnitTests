using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuzluCacıkAPI.Dto;
using MuzluCacıkAPI.Models;
using MuzluCacıkAPI.Repository;

namespace MuzluCacıkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerController(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Player>))]
        public IActionResult GetPlayers()
        {
            var players = _mapper.Map<List<PlayerDto>>(_playerRepository.GetAllPlayers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(players);
        }

        [HttpGet("{playerId}")]
        [ProducesResponseType(200, Type = typeof(Player))]
        [ProducesResponseType(400)]
        public IActionResult GetPlayer(int playerId)
        {
            if (!_playerRepository.PlayersExist(playerId))
            {
                return NotFound();
            }
            var player = _mapper.Map<PlayerDto>(_playerRepository.GetPlayerById(playerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(player);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePlayer([FromBody] PlayerDto player)
        {
            if (player == null)
            {
                return BadRequest();
            }
            var newPlayer = _playerRepository.GetAllPlayers()
                .Where(p => p.Name.Trim().ToUpper() == player.Name.ToUpper())
                .FirstOrDefault();
            if (newPlayer != null)
            {
                ModelState.AddModelError("", "Player already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerMap = _mapper.Map<Player>(newPlayer);
            if (!_playerRepository.CreatePlayer(playerMap.Name, playerMap.BirthDate))
            {
                ModelState.AddModelError("", "Something went wrong while saving.Try again.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{playerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePlayer([FromBody] PlayerDto player)
        {
            if (player == null)
            {
                return BadRequest(ModelState);
            }
            if (!_playerRepository.PlayersExist(player.Id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var playerMap = _mapper.Map<Player>(player);
            if (!_playerRepository.UpdatePlayer(playerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.Try again.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{playerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePlayer(int playerId)
        {
            if (!_playerRepository.PlayersExist(playerId))
            {
                return NotFound();
            }
            var playerToDelete = _playerRepository.GetPlayerById(playerId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_playerRepository.DeletePlayer(playerToDelete.Id))
            {
                ModelState.AddModelError("", "Something went wrong while saving.Try again.");
            }
            return NoContent();
        }
    }
}
