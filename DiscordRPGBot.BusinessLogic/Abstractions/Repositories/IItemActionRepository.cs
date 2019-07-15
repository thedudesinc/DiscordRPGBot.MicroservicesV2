using DiscordRPGBot.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Repositories
{
    public interface IItemActionRepository
    {
        Task<ItemAction> GetAsync(long id);
        Task<IEnumerable<ItemAction>> GetAllAsync();
        Task<ItemAction> GetByDescription(string description);
        Task<IEnumerable<ItemAction>> GetAllByItemIdAsync(long id);
        Task<long> CreateAsync(ItemAction action);
        Task CreateAsync(IEnumerable<ItemAction> action);
        Task UpdateAsync(long id, ItemAction action);
        Task<bool> DeleteAsync(long id);
    }
}
