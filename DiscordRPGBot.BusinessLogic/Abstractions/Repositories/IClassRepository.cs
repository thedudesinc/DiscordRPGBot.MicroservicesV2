using DiscordRPGBot.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Abstractions.Repositories
{
    public interface IClassRepository
    {
        Task<Class> GetAsync(long id);
        Task<Class> GetByNameAsync(string name);
        Task<IEnumerable<Class>> GetAsync(IEnumerable<long> ids);
        Task<long> CreateAsync(Class @class);
        Task CreateAsync(IEnumerable<Class> @class);
        Task UpdateAsync(long id, Class @class);
        Task<bool> DeleteAsync(long id);
    }
}
