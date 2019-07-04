using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Abstractions.Services;
using DiscordRPGBot.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Services
{
    public class PlayerCharacterService : IPlayerCharacterService
    {
        private readonly IPlayerCharacterRepository _repository;

        public PlayerCharacterService(IPlayerCharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> CreateAsync(PlayerCharacter pc)
        {
            var id = await _repository.CreateAsync(pc);

            return id;
        }

        public async Task CreateAsync(IEnumerable<PlayerCharacter> pcs)
        {
            await _repository.CreateAsync(pcs);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var deleted = await _repository.DeleteAsync(id);

            return deleted;
        }

        public async Task<PlayerCharacter> GetAsync(long id)
        {
            var pc = await _repository.GetAsync(id);

            return pc;
        }

        public async Task<IEnumerable<PlayerCharacter>> GetAsync(IEnumerable<long> ids)
        {
            var pcs = await _repository.GetAsync(ids);

            return pcs;
        }

        public async Task UpdateAsync(long id, PlayerCharacter pc)
        {
            await _repository.UpdateAsync(id, pc);
        }
    }
}
