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
    public class UserRepository : IUserRepository
    {
        private readonly DiscordRPGBotContext _context;

        public UserRepository(DiscordRPGBotContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task AddCharacterToUserAsync(long userId, PlayerCharacter pc)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                if (user.Characters != null)
                {
                    user.Characters.Add(pc);
                }
                else
                {
                    user.Characters = new[] { pc };
                }
                
                await SetActiveCharacterAsync(userId, pc.Id);
               
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found when adding character to user!");
            }
        }

        public async Task RemoveCharacterFromUserAsync(long userId, PlayerCharacter pc)
        {
            var user = await _context.Users.FindAsync(userId);  

            if (user != null)
            {
                if (user.Characters.Where(c => c.Id == pc.Id).Count() > 0)
                {
                    user.Characters.Remove(pc);

                    if (user.Characters.Count > 0)
                    {
                        await SetActiveCharacterAsync(userId, user.Characters.First().Id);
                    }
                    else
                    {
                        await SetActiveCharacterAsync(userId, null);
                    }
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found when removing character from user!");
            }
        }

        public async Task SetActiveCharacterAsync(long userId, long? id)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.ActiveCharacter = id;

                await _context.SaveChangesAsync();
            }
            else
            {
                user.ActiveCharacter = null;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<long> CreateAsync(User user)
        {
            var savedUser = _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return savedUser.Entity.Id;
        }

        public async Task CreateAsync(IEnumerable<User> user)
        {
            _context.Users.AddRange(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var userToDelete = _context.Users.Find(id);

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteByDiscordIdAsync(string discordId)
        {
            var userToDelete = _context.Users.Where(u => u.DiscordId == discordId).FirstOrDefault();

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> GetAsync(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAsync(IEnumerable<long> ids)
        {
            return await Task.FromResult(_context.Users.Where(p => ids.Contains(p.Id)).ToArray());
        }

        public async Task<User> GetByDiscordIdAsync(string discordId)
        {
            return await Task.FromResult(_context.Users
                .Include(u => u.Characters)
                .Where(p => p.DiscordId.ToLower() == discordId.Trim().ToLower())
                .FirstOrDefault());
        }

        public async Task UpdateAsync(long id, User user)
        {
            await Task.FromResult(_context.Users.Update(user));
        }
    }
}
