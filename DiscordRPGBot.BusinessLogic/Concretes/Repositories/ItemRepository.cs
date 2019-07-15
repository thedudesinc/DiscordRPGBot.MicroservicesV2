using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DiscordRPGBotContext _context;

        public ItemRepository(DiscordRPGBotContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<long> CreateAsync(Item item)
        {
            var savedItem = _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return savedItem.Entity.Id;
        }

        public async Task CreateAsync(IEnumerable<Item> item)
        {
            _context.Items.AddRange(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var itemToDelete = _context.Classes.Find(id);

            if (itemToDelete != null)
            {
                _context.Classes.Remove(itemToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await Task.FromResult(_context.Items.ToArray());
        }

        public async Task<Item> GetAsync(long id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.Items.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task UpdateAsync(long id, Item item)
        {
            await Task.FromResult(_context.Items.Update(item));
        }
    }
}
