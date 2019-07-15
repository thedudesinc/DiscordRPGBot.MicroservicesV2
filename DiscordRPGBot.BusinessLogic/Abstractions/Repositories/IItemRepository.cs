using DiscordRPGBot.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetAsync(long id);
        Task<IEnumerable<Item>> GetAllAsync();
        Task<IEnumerable<Item>> GetAsync(IEnumerable<long> ids);
        Task<long> CreateAsync(Item action);
        Task CreateAsync(IEnumerable<Item> action);
        Task UpdateAsync(long id, Item action);
        Task<bool> DeleteAsync(long id);
    }
}
