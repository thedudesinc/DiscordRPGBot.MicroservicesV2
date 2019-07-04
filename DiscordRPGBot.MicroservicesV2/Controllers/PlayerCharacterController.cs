using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRPGBot.BusinessLogic.Abstractions.Services;
using DiscordRPGBot.BusinessLogic.Entities;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerCharacter>> Get(long id)
        {
            var pc = await _service.GetAsync(id);

            return Ok(pc);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] PlayerCharacter playerCharacter)
        {
            var id = await _service.CreateAsync(playerCharacter);

            return Ok(id);
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
