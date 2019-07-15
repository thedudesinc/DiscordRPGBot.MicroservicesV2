using DiscordRPGBot.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Repositories
{
    public interface ILocationActionRepository
    {
        Task<LocationAction> GetAsync(long id);
        Task<IEnumerable<LocationAction>> GetAllAsync();
        Task<LocationAction> GetByDescription(string description);
        Task<IEnumerable<LocationAction>> GetAllByLocationIdAsync(long id);
        Task<long> CreateAsync(LocationAction action);
        Task CreateAsync(IEnumerable<LocationAction> action);
        Task UpdateAsync(long id, LocationAction action);
        Task<bool> DeleteAsync(long id);
    }
}
