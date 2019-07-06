using System;
using System.Threading.Tasks;
using DiscordRPGBot.BusinessLogic.Abstractions.Services;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Models.Request;
using DiscordRPGBot.BusinessLogic.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscordRPGBot.MicroservicesV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerCharacterController : ControllerBase
    {
        private readonly IPlayerCharacterService _service;

        public PlayerCharacterController(IPlayerCharacterService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<PlayerCharacter>> Get()
        //{
        //    //implement TODO: get all playercharacters
        //}

        [HttpGet("{discordId}")]
        public async Task<ActionResult<PlayerCharacterGetResponse>> Get(string discordId)
        {
            try
            {
                var pcSummary = await _service.GetAsync(discordId);

                return Ok(pcSummary);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] PlayerCharacterCreateRequest playerCharacter)
        {
            try
            {
                var id = await _service.CreateAsync(playerCharacter);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);

            return Ok(deleted);
        }
    }
}
