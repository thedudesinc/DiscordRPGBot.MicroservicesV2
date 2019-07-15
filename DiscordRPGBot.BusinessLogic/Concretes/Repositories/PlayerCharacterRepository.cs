using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Repositories
{
    public class PlayerCharacterRepository : IPlayerCharacterRepository
    {
        private readonly DiscordRPGBotContext _context;

        public PlayerCharacterRepository(DiscordRPGBotContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<long> CreateAsync(PlayerCharacter pc)
        {
            var addedPC = _context.PlayerCharacters.Add(pc);

            await _context.SaveChangesAsync();

            return addedPC.Entity.Id;
        }

        public async Task CreateAsync(IEnumerable<PlayerCharacter> pcs)
        {
            _context.PlayerCharacters.AddRange(pcs);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entityToRemove = await GetAsync(id);

            if (entityToRemove != null)
            {
                _context.PlayerCharacters.Remove(entityToRemove);

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<PlayerCharacter> GetAsync(long id)
        {
            return await Task.FromResult(_context.PlayerCharacters
                .Include(p => p.Race)
                .Include(p => p.Class)
                .Include(p => p.User)
                .Include(a => a.Location)
                    .ThenInclude(a => a.Actions)
                .Include(a => a.Items)
                .Where(pc => pc.Id == id).Single());
        }

        public async Task<IEnumerable<PlayerCharacter>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.PlayerCharacters.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task UpdateAsync(long id, PlayerCharacter pc)
        {
            _context.PlayerCharacters.Update(pc);

            await _context.SaveChangesAsync();
        }
    }
}
