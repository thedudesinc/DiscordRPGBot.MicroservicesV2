using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Services
{
    public interface IActionService
    {
        Task<List<string>> GetActionsForPlayerCharacterAsync(string discordId);
        Task<string> DoActionAsync(string discordId, int actionNumber);
    }
}
