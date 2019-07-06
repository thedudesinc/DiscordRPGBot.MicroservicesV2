using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DiscordRPGBotContext _context;

        public ClassRepository(DiscordRPGBotContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<long> CreateAsync(Class user)
        {
            var savedClass = _context.Classes.Add(user);
            await _context.SaveChangesAsync();

            return savedClass.Entity.Id;
        }

        public async Task CreateAsync(IEnumerable<Class> user)
        {
            _context.Classes.AddRange(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var classToDelete = _context.Classes.Find(id);

            if (classToDelete != null)
            {
                _context.Classes.Remove(classToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Class> GetAsync(long id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<IEnumerable<Class>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.Classes.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task<Class> GetByNameAsync(string name)
        {
            var @class = await Task.FromResult(_context.Classes.Where(p => p.Name.ToLower() == name.Trim().ToLower()).FirstOrDefault());

            if (@class != null)
            {
                return @class;
            }
            else
            {
                throw new Exception("A class with that name does not exist!");
            }
        }

        public async Task UpdateAsync(long id, Class @class)
        {
            await Task.FromResult(_context.Classes.Update(@class));
        }
    }
}
