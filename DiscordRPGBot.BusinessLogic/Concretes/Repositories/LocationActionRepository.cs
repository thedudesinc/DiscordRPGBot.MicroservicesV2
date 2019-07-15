using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Repositories
{
    public class LocationActionRepository : ILocationActionRepository
    {
        private readonly DiscordRPGBotContext _context;

        public LocationActionRepository(DiscordRPGBotContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<long> CreateAsync(LocationAction action)
        {
            var savedAction = _context.LocationActions.Add(action);
            await _context.SaveChangesAsync();

            return savedAction.Entity.Id;
        }

        public async Task CreateAsync(IEnumerable<LocationAction> action)
        {
            _context.LocationActions.AddRange(action);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var actionToDelete = _context.Classes.Find(id);

            if (actionToDelete != null)
            {
                _context.Classes.Remove(actionToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<LocationAction>> GetAllAsync()
        {
            return await Task.FromResult(_context.LocationActions.ToArray());
        }

        public async Task<IEnumerable<LocationAction>> GetAllByLocationIdAsync(long id)
        {
            return await Task.FromResult(_context.LocationActions.Where(p => p.Location.Id == id).ToArray());
        }

        public async Task<LocationAction> GetAsync(long id)
        {
            return await _context.LocationActions.FindAsync(id);
        }

        public async Task<IEnumerable<LocationAction>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.LocationActions.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task<LocationAction> GetByDescription(string description)
        {
            return await Task.FromResult(_context.LocationActions.Where(p => p.Description == description).FirstOrDefault());
        }

        public async Task UpdateAsync(long id, LocationAction action)
        {
            await Task.FromResult(_context.LocationActions.Update(action));
        }
    }
}
