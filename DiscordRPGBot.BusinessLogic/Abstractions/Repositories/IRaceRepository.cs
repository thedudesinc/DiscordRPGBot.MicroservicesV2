using DiscordRPGBot.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Repositories
{
    public interface IRaceRepository
    {
        Task<Race> GetAsync(long id);
        Task<Race> GetByNameAsync(string name);
        Task<IEnumerable<Race>> GetAsync(IEnumerable<long> ids);
        Task<long> CreateAsync(Race race);
        Task CreateAsync(IEnumerable<Race> race);
        Task UpdateAsync(long id, Race race);
        Task<bool> DeleteAsync(long id);
    }
}
