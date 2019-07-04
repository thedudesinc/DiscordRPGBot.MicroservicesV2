using DiscordRPGBot.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Services
{
    public interface IPlayerCharacterService
    {
        Task<PlayerCharacter> GetAsync(long id);
        Task<IEnumerable<PlayerCharacter>> GetAsync(IEnumerable<long> ids);
        Task<long> CreateAsync(PlayerCharacter pc);
        Task CreateAsync(IEnumerable<PlayerCharacter> pcs);
        Task UpdateAsync(long id, PlayerCharacter pc);
        Task<bool> DeleteAsync(long id);
    }
}
