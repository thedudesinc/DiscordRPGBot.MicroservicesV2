﻿using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Repositories;
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
            var removedEntity = await GetAsync(id);

            _context.PlayerCharacters.Remove(removedEntity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PlayerCharacter> GetAsync(long id)
        {
            return await _context.PlayerCharacters.FindAsync(id);
        }

        public async Task<IEnumerable<PlayerCharacter>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.PlayerCharacters.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task UpdateAsync(long id, PlayerCharacter pc)
        {
            await Task.FromResult(_context.PlayerCharacters.Update(pc));
        }
    }
}