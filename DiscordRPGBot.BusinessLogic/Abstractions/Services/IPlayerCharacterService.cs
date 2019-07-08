using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Models.Request;
using DiscordRPGBot.BusinessLogic.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Services
{
    public interface IPlayerCharacterService
    {
        Task<PlayerCharacterGetResponse> GetAsync(string discordId);
        Task<IEnumerable<PlayerCharacterGetResponse>> GetAsync(IEnumerable<long> ids);
        Task<IEnumerable<PlayerCharacterGetResponse>> GetAllByDiscordId(string discordId);
        Task<PlayerCharacterGetResponse> SetActiveCharacterByOrderedName(string discordId, int orderId);
        Task SetCharacterProfileImageAsync(string discordId, string imageUrl);
        Task<long> CreateAsync(PlayerCharacterCreateRequest pc);
        Task CreateAsync(IEnumerable<PlayerCharacter> pcs);
        Task UpdateAsync(long id, PlayerCharacter pc);
        Task<bool> DeleteAsync(long id);
    }
}
