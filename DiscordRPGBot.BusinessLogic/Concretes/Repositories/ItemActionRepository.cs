using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Repositories
{
    public class ItemActionRepository : IItemActionRepository
    {
        private readonly DiscordRPGBotContext _context;

        public ItemActionRepository(DiscordRPGBotContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<long> CreateAsync(ItemAction action)
        {
            var savedAction = _context.ItemActions.Add(action);
            await _context.SaveChangesAsync();

            return savedAction.Entity.Id;
        }

        public async Task CreateAsync(IEnumerable<ItemAction> action)
        {
            _context.ItemActions.AddRange(action);
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

        public async Task<IEnumerable<ItemAction>> GetAllAsync()
        {
            return await Task.FromResult(_context.ItemActions.ToArray());
        }

        public async Task<IEnumerable<ItemAction>> GetAllByItemIdAsync(long id)
        {
            return await Task.FromResult(_context.ItemActions.Where(p => p.Item.Id == id).ToArray());
        }

        public async Task<ItemAction> GetAsync(long id)
        {
            return await _context.ItemActions.FindAsync(id);
        }

        public async Task<IEnumerable<ItemAction>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.ItemActions.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task<ItemAction> GetByDescription(string description)
        {
            return await Task.FromResult(_context.ItemActions.Where(p => p.Description == description).FirstOrDefault());
        }

        public async Task UpdateAsync(long id, ItemAction action)
        {
            await Task.FromResult(_context.ItemActions.Update(action));
        }
    }
}
