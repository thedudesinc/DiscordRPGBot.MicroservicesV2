using DiscordRPGBot.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(long id);
        Task<User> GetByDiscordIdAsync(string discordId);
        Task<IEnumerable<User>> GetAsync(IEnumerable<long> ids);
        Task<long> CreateAsync(User user);
        Task CreateAsync(IEnumerable<User> user);
        Task UpdateAsync(long id, User user);
        Task SetActiveCharacterAsync(long userId, long? id);
        Task AddCharacterToUserAsync(long userId, PlayerCharacter pc);
        Task RemoveCharacterFromUserAsync(long userId, PlayerCharacter pc);
        Task<IEnumerable<PlayerCharacter>> GetPlayerCharactersByDiscordIdAsync(string discordId);
        Task<PlayerCharacter> GetActivePlayerCharacterByDiscordIdAsync(string discordId);
        Task<bool> DeleteAsync(long id);
        Task<bool> DeleteByDiscordIdAsync(string discordId);
    }
}
