using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRPGBot.BusinessLogic.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscordRPGBot.MicroservicesV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionService _service;

        public ActionController(IActionService service)
        {
            _service = service;
        }

        [HttpGet("{discordId}")]
        public async Task<ActionResult<List<string>>> Get(string discordId)
        {
            try
            {
                var actions = await _service.GetActionsForPlayerCharacterAsync(discordId);

                return Ok(actions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Do/{discordId}/{actionNumber}")]
        public async Task<ActionResult<string>> Do(string discordId, int actionNumber)
        {
            try
            {
                var result = await _service.DoActionAsync(discordId, actionNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}