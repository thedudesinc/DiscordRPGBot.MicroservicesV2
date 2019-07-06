using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly DiscordRPGBotContext _context;

        public RaceRepository(DiscordRPGBotContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<long> CreateAsync(Race user)
        {
            var savedRace = _context.Races.Add(user);
            await _context.SaveChangesAsync();

            return savedRace.Entity.Id;
        }

        public async Task CreateAsync(IEnumerable<Race> user)
        {
            _context.Races.AddRange(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var classToDelete = _context.Races.Find(id);

            if (classToDelete != null)
            {
                _context.Races.Remove(classToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Race> GetAsync(long id)
        {
            return await _context.Races.FindAsync(id);
        }

        public async Task<IEnumerable<Race>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.Races.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task<Race> GetByNameAsync(string name)
        {
            var race = await Task.FromResult(_context.Races.Where(p => p.Name.ToLower() == name.Trim().ToLower()).FirstOrDefault());

            if (race != null)
            {
                return race;
            }
            else
            {
                throw new Exception("A race with that name does not exist!");
            }
        }

        public async Task UpdateAsync(long id, Race race)
        {
            await Task.FromResult(_context.Races.Update(race));
        }
    }
}
